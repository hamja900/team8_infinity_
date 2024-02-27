using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuenManager : SingletoneBase<TuenManager>
{
    int globalTrun;
    public event Action<int> MonsterTurn;//������ ����
    public void PlayerTurns(int useTurn)
    {
        globalTrun += useTurn;
        MonsterTurn?.Invoke(useTurn); //choice �����ؼ� ����
    }
}
