using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuenManager : MonoBehaviour
{
    public static TuenManager i;
    float globalTrun;
    public event Action<float> MonsterTurn;
    private void Awake()
    {
        i = this;
    }
    public void PlayerTurns(float useTurn,PlayerInputScript player)
    {
        globalTrun += useTurn;
        player.enabled = false;
        MonsterTurn?.Invoke(useTurn);
        player.enabled = true;
    }
}
