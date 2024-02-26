using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    None,
    Weapon,
    Top,
    Bottom,
}
public enum ExpendType
{
    None,
    Heal,
    Cure,
    Hunger,
}
[CreateAssetMenu(fileName = "NewItem", menuName = "Items/NewItems")]
public class ItemSO : ScriptableObject
{
    [Header("General")]
    public Sprite itemSprite;
    public GameObject dropPrefab;
    public bool isStacking;
    public int maxStack;

    [Header("Expendable")]  
    public ExpendType expendType;
    public int healPoint;
    public int HungerPoint;
    
    [Header("Equipable")]
    public EquipType equipType;
    public int attackRange = 0;
    public int attackSpeed = 0;
    public int atk;
    public int def;
    public bool isEquipped=false;

}
