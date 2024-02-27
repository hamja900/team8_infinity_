using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 나누어진 공간들로 방을만들고 복도, 벽을 만드는 역할수행
public class MakeRandomMap : MonoBehaviour
{
    //방을 만들때 쓰이는 변수들
    [SerializeField] private int distance; // 방과 방과의 최소 거리
    [SerializeField] private int minRoomWidth;
    [SerializeField] private int minRoomHeight;

    // spaceList가져오는용도
    [SerializeField] private DivideSpace divideSpace;

    // 타일까는용도
    [SerializeField] private SpreadTilemap spreadTilemap;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject entrance;

    private HashSet<Vector2Int> floor;
    private HashSet<Vector2Int> wall;

    private void Start()
    {
        StartRandomMap();
    }

    private void StartRandomMap()
    {
        spreadTilemap.ClearAllTiles(); //깔려있는 모든타일 제거

        divideSpace.totalSpace = new RectangleSpace(new Vector2Int(0, 0), divideSpace.totalWidth, divideSpace.totalHeight);
        divideSpace.spaceList = new List<RectangleSpace>();

        floor = new HashSet<Vector2Int>();
        wall = new HashSet<Vector2Int>();
        divideSpace.DivideRoom(divideSpace.totalSpace);
        //방
        MakeRandomRooms();
        //복도
        //MakeCorridors();
        //벽
        //MakeWall();

        spreadTilemap.SpreadFloorTilemap(floor);
        //spreadTilemap.SpreadWallTilemap(wall);

        //player.transform.position = (Vector2)divideSpace.spaceList[0].Center();
        //entrance.transform.position = (Vector2)divideSpace.spaceList[divideSpace.spaceList.Count - 1].Center();
    }

    // space리스트에 있는 모든 리스트의 MakeARandomRectangleRoom을 콜하고 리턴되는 방의좌표들을 UnionWith를 통해 floor에 추가
    // UnionWith 는 HashSet의 함수인데 합집합이라고 생각하면 된다.
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

    private void MakeCorridors()
    {
        List<Vector2Int> tempCenters = new List<Vector2Int>();

        foreach(var space in divideSpace.spaceList)
        {
            tempCenters.Add(new Vector2Int(space.Center().x, space.Center().y));
        }
        Vector2Int nextCenter;
        Vector2Int currentCenter = tempCenters[0];
        tempCenters.Remove(currentCenter);

        while(tempCenters.Count != 0)
        {
            nextCenter = ChooseShortestNextCorridor(tempCenters, currentCenter);
            MakeOneCorridor(currentCenter, nextCenter);
            currentCenter = nextCenter;
            tempCenters.Remove(currentCenter);
        }
    }

    private Vector2Int ChooseShortestNextCorridor(List<Vector2Int> tempCenters, Vector2Int previousCenter)
    {
        int n = 0;
        float minLength = float.MaxValue;

        for(int i = 0; i < tempCenters.Count; i++)
        {
            if (Vector2.Distance(previousCenter, tempCenters[i]) < minLength)
            {
                minLength = Vector2.Distance(previousCenter, tempCenters[i]);
                n = i;
            }
        }
        return tempCenters[n];
    }

    private void MakeOneCorridor(Vector2Int currentCenter, Vector2Int nextCenter)
    {
        Vector2Int current = new Vector2Int(currentCenter.x, currentCenter.y);
        Vector2Int next = new Vector2Int(nextCenter.x, nextCenter.y);
        floor.Add(current);

        while(current.x != next.x)
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
        while(current.y != next.y)
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
