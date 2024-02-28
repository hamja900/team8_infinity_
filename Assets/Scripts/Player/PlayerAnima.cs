using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnima : MonoBehaviour
{
    Animator ani;
    SpriteRenderer characterSprite;
    PlayerAttack Pattack;
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
    void AttackAnima()
    {
        ani.SetTrigger("IsAttack");
        Pattack.AttackEvent();// attack 애니메이션 종료후 호출
    }
    public void MoveAnima(bool b)
    {
        ani.SetBool("IsMove",b);
    }
}
