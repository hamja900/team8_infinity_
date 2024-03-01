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
    int hpDeduction = 1; //조절 later
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
        if (Inventory.instance != null && Inventory.instance.equipUiSlots[0].curSlot != null)
        {
            return atk + Inventory.instance.equipUiSlots[0].curSlot.items.atk;
        }
        return atk;
    }
    public int GetDef()
    {
        if (Inventory.instance != null)
        {
            if (Inventory.instance.equipUiSlots[1].curSlot != null && Inventory.instance.equipUiSlots[2].curSlot != null)
            {
                return def + Inventory.instance.equipUiSlots[1].curSlot.items.def + Inventory.instance.equipUiSlots[2].curSlot.items.def;
            }
            if (Inventory.instance.equipUiSlots[1].curSlot != null)
            {
                return def + Inventory.instance.equipUiSlots[1].curSlot.items.def;
            }
            if (Inventory.instance.equipUiSlots[2].curSlot != null)
            {
                return def + Inventory.instance.equipUiSlots[2].curSlot.items.def;
            }
        }
        return def;
    }
    public int AttackSpeed()
    {
        if (Inventory.instance != null && Inventory.instance.equipUiSlots[0].curSlot != null)
        {
            return attackSpeed + Inventory.instance.equipUiSlots[0].curSlot.items.attackSpeed;
        }
        return attackSpeed;
    }
    public int MoveSpeed()
    {
        return moveSpeed;//상태 여부 반영
    }
    public void SetAttackRange()
    {
        int totalRange = attackRange;
        if (Inventory.instance != null && Inventory.instance.equipUiSlots[0].curSlot != null)
        {
            totalRange = attackRange + Inventory.instance.equipUiSlots[0].curSlot.items.attackRange;
        }
        GetComponent<BoxCollider2D>().size = new Vector2(totalRange, totalRange);
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
