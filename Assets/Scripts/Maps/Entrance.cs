using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    [SerializeField] MakeRandomMap makeRandomMap;
    [SerializeField] private GameObject MoveUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
        //플레이어 받으면 TAG로 변경
        //플레이어가 계단에 닿으면 팝업? 선택지? 출현
        if (collision.gameObject.name == "Player")
        {
            MoveUI.SetActive(true);
            StartCoroutine(PuzGame());
        }
    }

    IEnumerator PuzGame()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0;
    }

    public void YesButton()
    {
        makeRandomMap.PlusCount();
        makeRandomMap.StartRandomMap();
        MoveUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void NoButton()
    {
        MoveUI.SetActive(false);
        Time.timeScale = 1;
    }
}
