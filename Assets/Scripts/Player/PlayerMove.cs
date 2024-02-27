using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMove : MonoBehaviour
{
    PlayerStats stats;
    Rigidbody2D rigi;
    int moveDelay = 10;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }
    public bool CanMove()
    {
        return true;
    }
    public void Move(Dir dir)
    {
        Vector2 direction = Vector2.zero;
        switch (dir)
        {
            case Dir.q:
                direction = new Vector2(-1, 1);
                break;
            case Dir.w:
                direction = Vector2.up;
                break;
            case Dir.e:
                direction = new Vector2(1, 1);
                break;
            case Dir.a:
                direction = Vector2.left;
                break;
            case Dir.d:
                direction = Vector2.right;
                break;
            case Dir.z:
                direction = new Vector2(-1, -1);
                break;
            case Dir.x:
                direction = Vector2.down;
                break;
            case Dir.c:
                direction = new Vector2(1, -1);
                break;
        }
        StartCoroutine(CharacterMove(direction));
        TuenManager.i.PlayerTurns(stats.MoveSpeed());
    }
    IEnumerator CharacterMove(Vector2 dir)
    {
        int curMoveDelay = 0;
        while (curMoveDelay < moveDelay)
        {
            rigi.MovePosition(rigi.position + dir / moveDelay);
            ++curMoveDelay;
            yield return null;
        }
    }
}
