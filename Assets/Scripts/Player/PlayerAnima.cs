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
    public void AttackAnima()
    {
        StartCoroutine("AttackAnimaCor");
    }
    public IEnumerator AttackAnimaCor()
    {
        ani.SetTrigger("IsAttack");
        yield return ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle");
        Pattack.AttackEvent();
    }
    public void MoveAnima(bool b)
    {
        ani.SetBool("IsMove",b);
    }
}
