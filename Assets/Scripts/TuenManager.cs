using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuenManager : SingletoneBase<TuenManager>
{
    int globalTrun;
    public event Action<int> MonsterTurn;//������ ����
    public event Action OnEnemyTurnOver;

    public void PlayerTurns(int useTurn)
    {
        globalTrun += useTurn;

        StartCoroutine(StartMonsterTurn(useTurn));
        //MonsterTurn?.Invoke(useTurn); //choice �����ؼ� ����
    }

    IEnumerator StartMonsterTurn(int useTurn)
    {
        yield return new WaitForFixedUpdate();
        MonsterTurn?.Invoke(useTurn); //choice �����ؼ� ����
    }

    public void EnemyTurnOver()
    {
        Debug.Log("Enemy Turn Over");
        OnEnemyTurnOver?.Invoke();
    }
}
