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

    public int index;

    private void Awake()
    {
    }

   
    public void Set(ItemSlot slot)
    {
        _curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.items.itemSprite;
        quantityText.text = slot.quantity > 1? slot.quantity.ToString() : string.Empty;
    }

    public void Clear()
    {
        _curSlot = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }
    public void OnButtonClick()
    {
        Inventory.instance.SelectedItem(index);
    }
}
