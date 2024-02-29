using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TuenManager : SingletoneBase<TuenManager>
{
    int globalTrun;
    public event Action<int> MonsterTurn;//변수명 수정
    public event Action OnEnemyTurnOver;
    int curTurn;
    public bool isPlayerTurn { get; private set; } = true;
    public void PlayerTurns(int useTurn)
    {
        globalTrun += useTurn;
        isPlayerTurn = false;
        curTurn = MonsterTurn.GetInvocationList().Count();
        MonsterTurn?.Invoke(useTurn); //choice 분할해서 전달
    }

    public void EnemyTurnOver()
    {
        Debug.Log("Enemy Turn Over");
        curTurn--;
        if (curTurn == 0)
        {
            isPlayerTurn = true;
        }
        OnEnemyTurnOver?.Invoke();
    }
}
