using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action PlayerDie;
    int attackSpeed  = 10;
    int moveSpeed = 10;
    public float hp  = 20;
    public float maxHp = 20;
    int hpRegenCount = 200;
    int curHpRegenCount;
    int hpRegen = 1;
    int hpDeductionCount = 200;
    int curHpDeductionCount;
    int hpDeduction = 1; //���� later
    int atk = 2;
    int def = 0;
    public float hunger = 4500;
    public float maxHunger = 4500;
    public float exp  = 0;
    public float maxExp = 20;
    int attackRange = 1;
    public int level  = 1;
    private void Start()
    {
        TuenManager.I.MonsterTurn += PlayerTurn;
    }
    public int Attack()
    {
        if (Inventory.instance != null && Inventory.instance.equipitems[0].items != null)
        {
            return atk + Inventory.instance.equipitems[0].items.atk;
        }
        return atk;
    }
    public int GetDef()
    {
        if (Inventory.instance != null)
        {
            if (Inventory.instance.equipitems[1].items != null && Inventory.instance.equipitems[2].items != null)
            {
                return def + Inventory.instance.equipitems[1].items.def + Inventory.instance.equipitems[2].items.def;
            }
            if (Inventory.instance.equipitems[1].items != null)
            {
                return def + Inventory.instance.equipitems[1].items.def;
            }
            if (Inventory.instance.equipitems[2].items != null)
            {
                return def + Inventory.instance.equipitems[2].items.def;
            }
        }
        return def;
    }
    public int AttackSpeed()
    {
        return attackSpeed;//��� ���� �ݿ�
    }
    public int MoveSpeed()
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
            LvUp();
        }
    }
    public void EatFood(int foodCount)
    {
        hunger += foodCount;
        if (hunger > maxHunger)
        {
            hunger = maxHunger;
        }
    }
    public void PlayerTurn(int turn)
    {
        while (turn > 0)
        {
            hunger--;
            turn--;
            if (hunger <= 0)
            {
                hunger = 0;
                curHpRegenCount = 0;
                curHpDeductionCount++;
                if (curHpDeductionCount >= hpDeductionCount)
                {
                    curHpDeductionCount = 0;
                    GetDmg(hpDeduction);
                }
            }
            if (hunger > 0)
            {
                curHpDeductionCount = 0;
                curHpRegenCount++;
                if (curHpRegenCount >= hpRegenCount)
                {
                    curHpRegenCount = 0;
                    HealHp(hpRegen);
                }
            }
        }
        TuenManager.I.EnemyTurnOver();
    }
    public void HealHp(int healing)
    {
        hp += healing;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
    public void GetDmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            PlayerDie?.Invoke();
        }
    }
    void LvUp()
    {
        exp -= maxExp;
        level++;
        maxHp += 5;
        hp = maxHp;
        atk += 4;
        def += 3;
    }
}
