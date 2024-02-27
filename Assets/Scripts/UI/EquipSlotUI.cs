using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlotUI : MonoBehaviour
{
    public Button button;
    public UnityEngine.UI.Image icon;
    private ItemSlot _curSlot;

    public int idx;

    public void Set(ItemSO so)
    {
        _curSlot.items = so;
        icon.gameObject.SetActive(true);
        icon.sprite = so.itemSprite;
    }
   

    public void Clear()
    {
        _curSlot = null;
        icon.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        Inventory.instance.SelectedItem(idx);
    }
}
