using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSpace
{
    // 직사각형 왼쪽아래 좌표 leftDown / 아래 3개가있으면 직사각형을 표현할수있다.
    public Vector2Int leftDown;
    public int width;
    public int height;

    // 직사각형 공간을 정의하는 역활 수행
    public RectangleSpace(Vector2Int leftDown, int width, int height)
    {
        this.leftDown = leftDown;
        this.width = width;
        this.height = height;
    }

    //공간의 중심좌표를 리턴하는 함수
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
