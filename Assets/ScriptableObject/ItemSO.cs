using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExpendType
{
    Heal,
    Cure,
    Hunger,
}
[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Expendable")]
public class ItemSO : ScriptableObject
{
    public ExpendType expendType;
    public int healPoint;
    public int HungerPoint;
    public Sprite itemSprite;

    public int maxStack;
}
