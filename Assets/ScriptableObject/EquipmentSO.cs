using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Weapon,
    Top,
    Bottom,
}

[CreateAssetMenu(fileName ="NewEquipment",menuName ="Items/Equipment")]
public class EquipmentSO : ScriptableObject
{
    public EquipType equipType;
    public int attackRange = 0;
    public int attackSpeed = 0;
    public int atk;
    public int def;
    public Sprite itemSprite;
}
