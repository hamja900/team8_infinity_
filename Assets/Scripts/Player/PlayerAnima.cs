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
    public void AttackAnima()
    {
        IsAttackAnima = true;
        ani.SetTrigger("IsAttack");
    }
    private void Update()
    {
        if (IsAttackAnima)
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack") == true)
            {
                float animTime = ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if (animTime >= 1.0f)
                {
                    Pattack.AttackEvent();
                    IsAttackAnima = false;
                    return;
                }
            }
        }
    }
    public void MoveAnima(bool b)
    {
        ani.SetBool("IsMove",b);
    }
}
