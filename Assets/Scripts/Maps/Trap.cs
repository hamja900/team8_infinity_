using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Trap : MonoBehaviour
{
    [SerializeField] MakeRandomMap makeRandomMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            StartCoroutine(StartTrap());
        }
    }

    IEnumerator StartTrap()
    {
        yield return new WaitForSeconds(0.2f);
        makeRandomMap.MinusCount(); // ¼öÁ¤
        HUD.instance.UpdateDungeonLevel();
        //makeRandomMap.StartRandomMap();
        GameManager.I.ReleaseAllEnemy();
        GameManager.I.DestroyItem();
        GameManager.I.MakeRandomEnemyList();
    }
}
