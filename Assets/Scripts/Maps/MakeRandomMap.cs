using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ������� ��������� ����, ���� ����� ���Ҽ���
public class MakeRandomMap : MonoBehaviour
{
    //���� ���鶧 ���̴� ������
    [SerializeField] private int distance; // ��� ����� �ּ� �Ÿ�
    [SerializeField] private int minRoomWidth;
    [SerializeField] private int minRoomHeight;

    // spaceList�������¿뵵
    [SerializeField] private DivideSpace divideSpace;

    // Ÿ�ϱ�¿뵵
    [SerializeField] private SpreadTilemap spreadTilemap;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject entrance;

    private HashSet<Vector2Int> floor;
    private HashSet<Vector2Int> wall;

    private int clearRoomNum = 0;

    private void Start()
    {
        StartRandomMap();
        entrance.SetActive(true);
    }
    public void PlusCount()
    {
        clearRoomNum++;
    }
    public void StartRandomMap()
    {
        spreadTilemap.ClearAllTiles(); //����ִ� ���Ÿ�� ����
        divideSpace.totalSpace = new RectangleSpace(new Vector2Int(0, 0), divideSpace.totalWidth, divideSpace.totalHeight);
        divideSpace.spaceList = new List<RectangleSpace>();

        floor = new HashSet<Vector2Int>();
        wall = new HashSet<Vector2Int>();
        divideSpace.DivideRoom(divideSpace.totalSpace);
        //��
        MakeRandomRooms();
        //����
        MakeCorridors();
        //��
        MakeWall();

        spreadTilemap.SpreadFloorTilemap(floor);
        spreadTilemap.SpreadWallTilemap(wall);

        //�÷��̾� ������ġ
        player.transform.position = (Vector2)divideSpace.spaceList[0].Center();
        //���� ������ġ

        //�ⱸ ������ġ <-�÷��̾�� ���� �� �濡 ���� + ������ �����濡 ����
        Stairs();
    }
    private void Stairs()
    {
        entrance.transform.position = (Vector2)divideSpace.spaceList[divideSpace.spaceList.Count - 1].Center();
        if (clearRoomNum == 2)
        {
            //entrance.SetActive(false);
            //�߰����� �������� ó�������� true�� �ٲٱ�
            //if
            Debug.Log("�߰�������");
        }
        else if(clearRoomNum == 4)
        {
            Debug.Log("����������");
        }
        else if(clearRoomNum == 5)
        {
            //������ ���
            Debug.Log("���� �Ϸ�");
        }
    }

    // space����Ʈ�� �ִ� ��� ����Ʈ�� MakeARandomRectangleRoom�� ���ϰ� ���ϵǴ� ������ǥ���� UnionWith�� ���� floor�� �߰�
    // UnionWith �� HashSet�� �Լ��ε� �������̶�� �����ϸ� �ȴ�.
    private void MakeRandomRooms()
    {
        foreach(var space in divideSpace.spaceList)
        {
            HashSet<Vector2Int> positions = MakeARandomRectangleRoom(space);
            floor.UnionWith(positions);
        }
    }

    private HashSet<Vector2Int> MakeARandomRectangleRoom(RectangleSpace space)
    {
        HashSet<Vector2Int> positnions = new HashSet<Vector2Int>();

        int width = Random.Range(minRoomWidth, space.width + 1 - distance * 2);
        int height = Random.Range(minRoomHeight, space.height + 1 - distance * 2);
        for (int i = space.Center().x - width / 2; i < space.Center().x + width / 2; i++) {
            for (int j = space.Center().y - height / 2; j < space.Center().y + height / 2; j++)
            {
                positnions.Add(new Vector2Int(i , j));
            }
        }
        return positnions;
    }

    //���������Լ�
    private void MakeCorridors()
    {
        //���� �߽��� �������� �̾�⶧���� ���� �߽ɸ���Ʈ�� ����
        List<Vector2Int> tempCenters = new List<Vector2Int>();
        foreach(var space in divideSpace.spaceList)
        {
            tempCenters.Add(new Vector2Int(space.Center().x, space.Center().y));
            tempCenters.Add(new Vector2Int(space.Center().x, space.Center().y));
        }

        Vector2Int nextCenter;
        Vector2Int currentCenter = tempCenters[0]; //������ �߽��� ���Ѵ�.
        //�߽��� ����Ʈ���� ���ܽ�Ų��.
        tempCenters.Remove(currentCenter);
        // �߽ɿ��� ���� ����� �߽��� ã�� ������ ������ش�.
        while (tempCenters.Count != 0)
        {
            nextCenter = ChooseShortestNextCorridor(tempCenters, currentCenter);
            MakeOneCorridor(currentCenter, nextCenter);
            currentCenter = nextCenter;
            tempCenters.Remove(currentCenter); //���ο��߽��� ����Ʈ���� �����Ѵ�.
        }
    }

    // ���� ����� �߽��� ã���ִ� �Լ�
    private Vector2Int ChooseShortestNextCorridor(List<Vector2Int> tempCenters, Vector2Int previousCenter)
    {
        int n = 0;
        float minLength = float.MaxValue;

        for(int i = 0; i < tempCenters.Count; i++)
        {
            //Distance�Լ���?
            if (Vector2.Distance(previousCenter, tempCenters[i]) < minLength)
            {
                minLength = Vector2.Distance(previousCenter, tempCenters[i]);
                n = i;
            }
        }
        return tempCenters[n];
    }

    // x,y�� ���븦 ������ �� �߽��� �մ� ������ �ϼ��ȴ�.
    private void MakeOneCorridor(Vector2Int currentCenter, Vector2Int nextCenter)
    {
        Vector2Int current = new Vector2Int(currentCenter.x, currentCenter.y);
        Vector2Int next = new Vector2Int(nextCenter.x, nextCenter.y);
        floor.Add(current);
        //���� �߽��� x��ǥ�� �����߽��� x��ǥ�� ������������ �̵��ϸ� ��������
        while (current.x != next.x)
        {
            if(current.x < next.x)
            {
                current.x += 1;
                floor.Add(current);
            }
            else
            {
                current.x -= 1;
                floor.Add(current);
            }
        }
        //���� �߽��� y��ǥ�� �����߽��� y��ǥ�� ������������ �̵��ϸ� ��������
        while (current.y != next.y)
        {
            if(current.y < next.y)
            {
                current.y += 1;
                floor.Add(current);
            }
            else
            {
                current.y -= 1;
                floor.Add(current);
            }
        }
    }

    // ���Ÿ�Ͽ����� 3*3���� ����� ������Ÿ���� �ٴ��� �ƴѰ��� �����Ѵ�.
    private void MakeWall()
    {
        foreach(Vector2Int tile in floor)
        {
            HashSet<Vector2Int> boundary = Mack3X3Square(tile);
            boundary.ExceptWith(floor);

            if (boundary.Count != 0)
            {
                wall.UnionWith(boundary);
            }
        }
    }

    private HashSet<Vector2Int> Mack3X3Square(Vector2Int tile)
    {
        HashSet<Vector2Int> boundary = new HashSet<Vector2Int>();

        for(int i = tile.x - 1; i <= tile.x + 1; i++)
        {
            for(int j = tile.y - 1; j <= tile.y + 1; j++)
            {
                boundary.Add(new Vector2Int(i, j));
            }
        }
        return boundary;
    }
}
