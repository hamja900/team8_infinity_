using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlotUI : MonoBehaviour
{ 
    public UnityEngine.UI.Image icon;
    public ItemSlot curSlot;

    public int index;

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.items.itemSprite;
    }
    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
    }

   
}
