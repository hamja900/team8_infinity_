using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotsUI : MonoBehaviour
{
    public UnityEngine.UI.Image icon;
    public Button button;
    private ItemSlot curSlot;

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

    public void OnButtonClick()
    {
        if (curSlot == null)
        {
            HUD.instance.previousSelectedHotKeyIndex = index;
            HUD.instance.ResisterHotKey();
        }
        else
        {
            Inventory.instance.itemUseMode = true;
            HUD.instance.UseItemConfirm.SetActive(true);
            HUD.instance.confirmIcon.sprite = curSlot.items.itemSprite;
        }


    }

}
