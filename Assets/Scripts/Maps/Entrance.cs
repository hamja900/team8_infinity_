using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [SerializeField] MakeRandomMap makeRandomMap;

    //클리어한 방의 개수
    private int clearRoomNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
        //플레이어 받으면 TAG로 변경
        if(collision.gameObject.name == "Player") 
        {
            makeRandomMap.StartRandomMap();
            clearRoomNum++;
        }
        Debug.Log(clearRoomNum);
    }
}
