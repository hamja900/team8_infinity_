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
        //�÷��̾� ������ TAG�� ����
        //�÷��̾ ��ܿ� ������ �˾�? ������? ����
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
