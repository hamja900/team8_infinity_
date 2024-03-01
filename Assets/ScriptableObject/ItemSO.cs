using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Expendable,
}
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
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public ItemType itemType;
    public GameObject dropPrefab;
    public bool canStack;
    public int maxStack;

    [Header("Expendable")]  
    public ExpendType expendType;
    public int healPoint;
    public int HungerPoint;
    
    [Header("Equipable")]
    public EquipType equipType;
    [Tooltip("짝수로 설정해야 합니다.")]
    public int attackRange = 0;
    [Tooltip("숫자가 높을수록 공격이 느려지고 최저 속도는 -9 입니다.")]
    public int attackSpeed = 0;
    public int atk;
    public int def;
    public bool isEquipped=false;

}
