using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int attackSpeed = 10;
    int moveSpeed = 10;
    float hp = 20;
    float maxHp = 20;
    int hpRegenCount = 20;
    int curHpRegenCount;
    int hpRegen = 1;
    int hpDeductionCount = 20;
    int curHpDeductionCount;
    int hpDeduction = 1;
    int atk = 5;
    int def = 0;
    int hunger = 4500;
    int maxHunger = 4500;
    int exp = 0;
    int maxExp = 20;
    int attackRange = 1;
    public int Attack()
    {
        return atk;//장비 여부 반영
    }
    public int AttackSpeed()
    {
        return attackSpeed;//장비 여부 반영
    }
    public int MoveSpeed()
    {
        return moveSpeed;//상태 여부 반영
    }
    public int AttackRange()
    {
        return attackRange;//장비 여부 반영
    }
    public void GetExp(int exp)
    {
        this.exp += exp;
        while (this.exp >= maxExp)
        {
            //lvup
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
    public void PlayerTurn(int turn) //turn 매니저와 연결해야함.
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
            //die
        }
    }
}
