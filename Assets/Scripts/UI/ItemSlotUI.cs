using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public UnityEngine.UI.Image icon;
    public TextMeshProUGUI quantityText;
    private ItemSlot _curSlot;
    public GameObject equipMark;

    public int index;
    public bool isEquipped;
    private void Awake()
    {

    }
    private void OnEnable()
    {
        if (_curSlot == null)
            return;
        equipMark.SetActive(isEquipped);
    }

    public void Set(ItemSlot slot)
    {
        _curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.items.itemSprite;
        quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : string.Empty;

    }

    public void Clear()
    {
        _curSlot = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }
    public void OnButtonClick()
    {
        if (Inventory.instance.itemResisterMode)
        {
            int hotkeyIndex = HUD.instance.previousSelectedHotKeyIndex;
            if (_curSlot == null || _curSlot.items == null || _curSlot.items.itemType == ItemType.Equipable)
                return;

            for (int i = 0; i < HUD.instance.quickUI.Length; i++)
            {
                if (HUD.instance.quickUI[i].CurSlot != null && HUD.instance.quickUI[i].CurSlot.items == _curSlot.items)
                {
                    HUD.instance.quickUI[i].Clear();
                }
            }
            HUD.instance.hotKey[hotkeyIndex] = _curSlot;
            HUD.instance.quickUI[hotkeyIndex].Set(_curSlot);

            Inventory.instance.itemResisterMode = false;
            Inventory.instance.inventoryWindow.SetActive(false);
        }
        else
            Inventory.instance.SelectedItem(index);
    }
}
