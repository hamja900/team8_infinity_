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
        //�÷��̾� ������ TAG�� ����
        //�÷��̾ ��ܿ� ������ �˾�? ������? ����
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
