using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuenManager : MonoBehaviour
{
    public static TuenManager i;
    int globalTrun;
    public event Action<int> MonsterTurn;
    private void Awake()
    {
        i = this;
    }
    public void PlayerTurns(int useTurn)
    {
        globalTrun += useTurn;
        MonsterTurn?.Invoke(useTurn);
    }
}
