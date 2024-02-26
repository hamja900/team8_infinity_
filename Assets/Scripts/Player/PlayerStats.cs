using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float attackSpeed = 1;
    float moveSpeed = 1;
    float hp = 20;
    float maxHp = 20;
    float afk = 5;
    int def = 0;
    int hunger = 500;
    int maxHunger = 500;
    int exp = 0;
    int maxExp = 20;
    int attackRange = 1;
    public float AttackSpeed()
    {
        return attackSpeed;//��� ���� �ݿ�
    }
    public float MoveSpeed()
    {
        return moveSpeed;//���� ���� �ݿ�
    }
    public int AttackRange()
    {
        return attackRange;//��� ���� �ݿ�
    }
    public void GetExp(int exp)
    {
        this.exp += exp;
        while (this.exp >= maxExp)
        {
            //lvup
        }
    }
}
