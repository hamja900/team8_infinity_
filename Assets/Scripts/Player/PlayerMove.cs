using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerStats stats;
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }
    public bool CanMove()
    {
        return false;
    }
    public void Move(Dir dir,PlayerInputScript input)
    {
        switch (dir)
        {
            case Dir.q:
                break;
            case Dir.w:
                break;
            case Dir.e:
                break;
            case Dir.a:
                break;
            case Dir.d:
                break;
            case Dir.z:
                break;
            case Dir.x:
                break;
            case Dir.c:
                break;
        }
        TuenManager.i.PlayerTurns(stats.MoveSpeed(),input);
    }
}
