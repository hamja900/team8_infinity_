using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnima : MonoBehaviour
{
    Animator ani;
    SpriteRenderer characterSprite;
    PlayerAttack Pattack;
    public bool IsAttackAnima { get; private set; } = false;
    private void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        characterSprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        Pattack = GetComponent<PlayerAttack>();
        Pattack.PAttackEvent += AttackAnima;
    }
    public void SpriteFileX(bool b)
    {
        characterSprite.flipX = b;
    }
    public void AttackAnima(bool b)
    {
        StartCoroutine(WaitAnima(b));
    }
    IEnumerator WaitAnima(bool b)
    {
        IsAttackAnima = true;
        SpriteFileX(b);
        ani.SetTrigger("IsAttack");
        b = true;
        while (b)
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack") == true)
            {
                float animTime = ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if (animTime >= 1f)
                {
                    b = false;
                }
            }
            yield return null;
        }
        while (!b)
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle") == true)
            {
                Pattack.AttackEvent();
                IsAttackAnima = false;
                break;
            }
            yield return null;
        }
    }
    public void MoveAnima(bool b)
    {
        ani.SetBool("IsMove", b);
    }
}
