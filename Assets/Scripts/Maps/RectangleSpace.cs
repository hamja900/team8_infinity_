using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSpace
{
    // ���簢�� ���ʾƷ� ��ǥ leftDown / �Ʒ� 3���������� ���簢���� ǥ���Ҽ��ִ�.
    public Vector2Int leftDown;
    public int width;
    public int height;

    // ���簢�� ������ �����ϴ� ��Ȱ ����
    public RectangleSpace(Vector2Int leftDown, int width, int height)
    {
        this.leftDown = leftDown;
        this.width = width;
        this.height = height;
    }

    //������ �߽���ǥ�� �����ϴ� �Լ�
    public Vector2Int Center()
    {
        return new Vector2Int(((leftDown.x * 2) + width - 1) / 2, ((leftDown.y * 2) + height - 1) / 2);
    }

    public Vector2Int GetRandomPosition()
    {
        //Vector2Int maxPosition = new Vector2Int(leftDown.x + width, leftDown.y + height);

        //int posX = leftDown.x + Random.Range(0, maxPosition.x);
        //int posY = leftDown.y + Random.Range(0, maxPosition.y);

        //return new Vector2Int(posX, posY);

        Vector2Int pos = Center();

        int posX = Random.Range(pos.x - width / 2 + 3, pos.x + width / 2 - 3);
        int posY = Random.Range(pos.y - height / 2 + 3, pos.y + height / 2 - 3);

        return new Vector2Int(posX, posY);
    }
}
