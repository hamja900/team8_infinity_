using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnima : MonoBehaviour
{
    Animator ani;
    SpriteRenderer characterSprite;
    PlayerAttack Pattack;
    bool isAttack = false;
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
        isAttack = true;
        ani.SetTrigger("IsAttack");
    }
    private void Update()
    {
        if (isAttack)
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack") == true)
            {
                float animTime = ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
                if (animTime >= 1.0f)
                {
                    Pattack.AttackEvent();
                    isAttack = false;
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
