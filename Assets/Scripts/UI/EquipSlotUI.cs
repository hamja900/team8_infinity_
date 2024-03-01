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

    public void Set(ItemSlot slot,int ind)
    {
        index = ind;
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.items.itemSprite;
        HUD.instance.player.GetComponent<PlayerStats>().SetAttackRange();
    }
    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
        index = -1;
        HUD.instance.player.GetComponent<PlayerStats>().SetAttackRange();
    }

   
}
