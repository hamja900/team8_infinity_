using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Entrance : MonoBehaviour
{
    [SerializeField] MakeRandomMap makeRandomMap;
    [SerializeField] private GameObject MoveUI;
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO
        //플레이어 받으면 TAG로 변경
        //플레이어가 계단에 닿으면 팝업? 선택지? 출현
        if (collision.gameObject.name == "Player")
        {
            MoveUI.SetActive(true);
            player = collision.gameObject;
            collision.gameObject.GetComponent<PlayerInput>().enabled = false;
            StartCoroutine(PuzGame());
        }
    }

    IEnumerator PuzGame()
    {
        yield return new WaitForSeconds(0.2f);
    }

    public void YesButton()
    {
        SoundManager.I.Play(SfxIndex.Walk,3);
        player.gameObject.GetComponent<PlayerInput>().enabled = true;
        makeRandomMap.PlusCount();
        //makeRandomMap.StartRandomMap();
        GameManager.I.MakeRandomEnemyList();
        HUD.instance.UpdateDungeonLevel();
        MoveUI.SetActive(false);
    }

    public void NoButton()
    {
        player.gameObject.GetComponent<PlayerInput>().enabled = true;
        MoveUI.SetActive(false);
    }
}
