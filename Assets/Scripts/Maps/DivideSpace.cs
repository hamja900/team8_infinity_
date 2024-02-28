using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 전체공간(totalSpace)를 나누고 리스트에 저장하는 역할
public class DivideSpace : MonoBehaviour
{
    // 전체공간의 너비와 높이
    public int totalWidth;
    public int totalHeight;
    // 공간이 가질수있는 최소 너비와 높이
    [SerializeField] private int minWidth;
    [SerializeField] private int minHeight;
    // 전체공간
    public RectangleSpace totalSpace;
    // 나누어진 공간을 저장하는 리스트
    public List<RectangleSpace> spaceList;

    // 파라미터로받은 space를 나누지 못할때까지 나눠서 나눈 공간들을 space리스트에 저장하는 함수
    // 너비 또는 높이가 최소치의 2배이상일경우 공간을 나눈다.
    public void DivideRoom(RectangleSpace space)
    {
        // 가로 또는 세로로 자른다.
        if(space.height >= minHeight * 2 && space.width >= minWidth * 2)
        {
            // 50퍼확률로 가로 또는 세로로 자른다.
            if(Random.Range(0,2) < 1)
            {
                RectangleSpace[] spaces = DivideHorizontal(space);

                DivideRoom(spaces[0]);
                DivideRoom(spaces[1]);
            }
            else
            {
                RectangleSpace[] spaces = DivideVertical(space);

                DivideRoom(spaces[0]);
                DivideRoom(spaces[1]);
            }
        }
        //세로로 자른다.
        else if(space.height < minHeight * 2 && space.width >= minWidth * 2)
        {
            RectangleSpace[] spaces = DivideVertical(space);

            DivideRoom(spaces[0]);
            DivideRoom(spaces[1]);
        }
        // 가로로 자른다
        else if (space.height >= minHeight * 2 && space.width < minWidth * 2)
        {
            RectangleSpace[] spaces = DivideHorizontal(space);

            DivideRoom(spaces[0]);
            DivideRoom(spaces[1]);
        }
        // 자르는 것을 멈추고 해당 공간을 리스트에 저장한다.
        else
        {
            spaceList.Add(space);
        }
    }

    // 공간을 가로로 자르는 함수 (높이기준)
    private RectangleSpace[] DivideHorizontal(RectangleSpace space)
    {
        int newSpace1Height = minHeight + Random.Range(0, space.height - minHeight * 2 + 1);
        RectangleSpace newSpace1 = new RectangleSpace(space.leftDown, space.width, newSpace1Height);

        int newSpace2Height = space.height - newSpace1Height;
        Vector2Int newSpace2LeftDown = new Vector2Int(space.leftDown.x, space.leftDown.y + newSpace1Height);
        RectangleSpace newSpace2 = new RectangleSpace(newSpace2LeftDown, space.width, newSpace2Height);

        RectangleSpace[] spaces = new RectangleSpace[2];
        spaces[0] = newSpace1;
        spaces[1] = newSpace2;

        return spaces;
    }
    // 공간을 세로로 자르는 함수 (너비 기준)
    private RectangleSpace[] DivideVertical(RectangleSpace space)
    {
        int newSpace1Width = minHeight + Random.Range(0, space.width - minWidth * 2 + 1);
        RectangleSpace newSpace1 = new RectangleSpace(space.leftDown, newSpace1Width, space.height);

        int newSpace2Width = space.width - newSpace1Width;
        Vector2Int newSpace2LeftDown = new Vector2Int(space.leftDown.x + newSpace1Width, space.leftDown.y);
        RectangleSpace newSpace2 = new RectangleSpace(newSpace2LeftDown, newSpace2Width, space.height);

        RectangleSpace[] spaces = new RectangleSpace[2];
        spaces[0] = newSpace1;
        spaces[1] = newSpace2;

        return spaces;
    }

    
}
