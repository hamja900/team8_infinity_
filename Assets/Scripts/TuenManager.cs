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
    public void PlayerTurns(int useTurn,PlayerInputScript player)
    {
        globalTrun += useTurn;
        player.enabled = false;
        MonsterTurn?.Invoke(useTurn);
        player.enabled = true;
    }
}
