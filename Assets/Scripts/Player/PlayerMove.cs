using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMove : MonoBehaviour
{
    PlayerStats stats;
    Rigidbody2D rigi;
    PlayerAnima aniScript;
    int moveDelay = 20;
    public static bool IsMoveing { get; private set; } = false;
    private void Awake()
    {
        aniScript = GetComponent<PlayerAnima>();
        rigi = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }
    public bool CanMove(Dir dir)
    {
        Vector2 direction = Vector2.zero;
        switch (dir)
        {
            case Dir.q:
                direction = new Vector2(-1, 1); aniScript.SpriteFileX(true);
                break;
            case Dir.w:
                direction = Vector2.up;
                break;
            case Dir.e:
                direction = new Vector2(1, 1); aniScript.SpriteFileX(false);
                break;
            case Dir.a:
                direction = Vector2.left; aniScript.SpriteFileX(true);
                break;
            case Dir.d:
                direction = Vector2.right; aniScript.SpriteFileX(false);
                break;
            case Dir.z:
                direction = new Vector2(-1, -1); aniScript.SpriteFileX(true);
                break;
            case Dir.x:
                direction = Vector2.down;
                break;
            case Dir.c:
                direction = new Vector2(1, -1); aniScript.SpriteFileX(false);
                break;
        }
        Vector2 targetPos = direction + (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(targetPos, Vector2.zero, 0.1f, LayerMask.GetMask("Wall", "Enemy"));

        if (!IsMoveing && hit.transform == null && !aniScript.IsAttackAnima)
        {
            IsMoveing = true;
            Move(direction);
            return true;
        }
        return false;
    }
    void Move(Vector2 direction)
    {
        StartCoroutine(CharacterMove(direction));
    }
    IEnumerator CharacterMove(Vector2 dir)
    {
        int curMoveDelay = 0;
        aniScript.MoveAnima(true);
        while (curMoveDelay < moveDelay)
        {
            rigi.position = (rigi.position + dir / moveDelay);
            ++curMoveDelay;
            yield return null;
        }
        //rigi.MovePosition(new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y)));
        aniScript.MoveAnima(false);
        TuenManager.I.PlayerTurns(stats.MoveSpeed());
        IsMoveing = false;
    }
}
