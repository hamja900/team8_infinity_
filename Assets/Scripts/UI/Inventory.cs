using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
[Serializable]
public class ItemSlot
{
    public ItemSO items;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public ItemSO[] testItems;

    public ItemSlotUI[] uiSlots;
    public EquipSlotUI[] equipUiSlots;
    public ItemSlot[] slots;
    public ItemSlot[] equipitems;

    private Equip equipScript;
    private PlayerStats playerStats;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("SelectedItem")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;

    public bool itemResisterMode = false;
    public bool itemUseMode = false;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
        equipScript = GetComponent<Equip>();
        playerStats = HUD.instance.player.GetComponent<PlayerStats>();
    }

    private void Start()
    {
        slots = new ItemSlot[uiSlots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        equipitems = new ItemSlot[equipUiSlots.Length];
        for (int j = 0; j < equipitems.Length; j++)
        {
            equipitems[j] = new ItemSlot();
            equipUiSlots[j].index = j;
            equipUiSlots[j].Clear();
        }
        
        ClearSelectedItemWindow();
        dropPosition = playerStats.gameObject.transform;
        AddItem(testItems[0]);
        AddItem(testItems[1]);
        AddItem(testItems[2]);
    }

    public void AddItem(ItemSO item)
    {
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if (slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }
        }
        ItemSlot emptySlot = GetEmptySlot();
        if (emptySlot != null)
        {
            emptySlot.items = item;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }
        ThrowItem(item);
    }

    private void ThrowItem(ItemSO item)
    {
        Instantiate(item.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one));
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

    private ItemSlot GetItemStack(ItemSO item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items == item && slots[i].quantity < item.maxStack)
                return slots[i];
        }
        return null;
    }

    private ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; ++i)
        {
            if (slots[i].items == null)
                return slots[i];
        }
        return null;
    }

    public void SelectedItem(int index)
    {
        if (slots[index].items == null)
            return;
        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.items.itemName;
        selectedItemDescription.text = selectedItem.items.itemDescription;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        if (selectedItem.items.itemType == ItemType.Expendable)
        {
            switch (selectedItem.items.expendType)
            {
                case ExpendType.Heal:
                    {
                        selectedItemStatName.text = "회복";
                        selectedItemStatValue.text = selectedItem.items.healPoint.ToString();
                    }
                    break;
                case ExpendType.Cure:
                    {

                    }
                    break;
                case ExpendType.Hunger:
                    {
                        selectedItemStatName.text = "포만도";
                        selectedItemStatValue.text = selectedItem.items.HungerPoint.ToString();
                    }
                    break;
            }
        }
        else if (selectedItem.items.itemType == ItemType.Equipable)
        {
            switch (selectedItem.items.equipType)
            {
                case EquipType.Weapon:
                    {
                        selectedItemStatName.text = "공격력";
                        selectedItemStatValue.text = selectedItem.items.atk.ToString();
                    }
                    break;
                case EquipType.Top:
                case EquipType.Bottom:
                    {
                        selectedItemStatName.text = "방어력";
                        selectedItemStatValue.text = selectedItem.items.def.ToString();
                    }
                    break;
            }
        }
        useButton.SetActive(selectedItem.items.itemType == ItemType.Expendable);
        equipButton.SetActive(selectedItem.items.itemType == ItemType.Equipable && !uiSlots[index].isEquipped);
        unEquipButton.SetActive(selectedItem.items.itemType == ItemType.Equipable && uiSlots[index].isEquipped);
        dropButton.SetActive(true);
    }
    void UpdateButtons()
    {
        useButton.SetActive(selectedItem.items.itemType == ItemType.Expendable);
        equipButton.SetActive(selectedItem.items.itemType == ItemType.Equipable && !uiSlots[selectedItemIndex].isEquipped);
        unEquipButton.SetActive(selectedItem.items.itemType == ItemType.Equipable && uiSlots[selectedItemIndex].isEquipped);
    }
    private void ClearSelectedItemWindow()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }
    public void OnUsebutton()
    {
        if (selectedItem.items.itemType == ItemType.Expendable)
        {
            switch (selectedItem.items.expendType)
            {
                case ExpendType.Heal:
                    {
                        playerStats.HealHp(selectedItem.items.healPoint);
                    }
                    break;
                case ExpendType.Cure:
                    {

                    }
                    break;
                case ExpendType.Hunger:
                    {
                        playerStats.EatFood(selectedItem.items.HungerPoint);
                    }
                    break;
            }
        }
        for (int i = 0; i < HUD.instance.quickUI.Length; i++)
        {
            if(selectedItem.items == HUD.instance.hotKey[i].items)
            {
                HUD.instance.hotKey[i].items = null;
            }
        }
        UpdateButtons();
        HUD.instance.UpdateQuickSlotUI();
        RemoveSelectedItem();
    }
    public void OnUsebutton(int hotkey)
    {
        selectedItem = HUD.instance.hotKey[hotkey];
        if (selectedItem.items.itemType == ItemType.Expendable)
        {
            switch (selectedItem.items.expendType)
            {
                case ExpendType.Heal:
                    {
                        playerStats.HealHp(selectedItem.items.healPoint);
                    }
                    break;
                case ExpendType.Cure:
                    {

                    }
                    break;
                case ExpendType.Hunger:
                    {
                        playerStats.EatFood(selectedItem.items.HungerPoint);
                    }
                    break;
            }
        }
        for (int i = 0; i < HUD.instance.quickUI.Length; i++)
        {
            if (selectedItem.items == HUD.instance.hotKey[i].items)
            {
                HUD.instance.hotKey[i].items = null;
            }
        }
        HUD.instance.hotKey[hotkey].items = null;
        HUD.instance.UpdateQuickSlotUI();
        RemoveSelectedItem();
    }
    public void OnEquipButton()
    {
        equipScript.EquipItem(selectedItemIndex);
        UpdateButtons();
    }
    public void OnUnEquipButton()
    {
        if (selectedItem.items.equipType == EquipType.Weapon)
            equipScript.UnEquipItem(selectedItemIndex, 0);
        else if (selectedItem.items.equipType == EquipType.Top)
            equipScript.UnEquipItem(selectedItemIndex, 1);
        else if (selectedItem.items.equipType == EquipType.Bottom)
            equipScript.UnEquipItem(selectedItemIndex, 2);

        UpdateButtons();
    }
    public void OnDropButton()
    {
        ThrowItem(selectedItem.items);
        UpdateButtons();
        RemoveSelectedItem();
    }
    public void OnQuitButton()
    {
        inventoryWindow.SetActive(false);
    }
    private void RemoveSelectedItem()
    {
        selectedItem.quantity--;
        if (selectedItem.quantity <= 0)
        {
            if (uiSlots[selectedItemIndex].isEquipped)
            {
                if (selectedItem.items.equipType == EquipType.Weapon)
                    equipScript.UnEquipItem(selectedItemIndex, 0);
                else if (selectedItem.items.equipType == EquipType.Top)
                    equipScript.UnEquipItem(selectedItemIndex, 1);
                else if (selectedItem.items.equipType == EquipType.Bottom)
                    equipScript.UnEquipItem(selectedItemIndex, 2);
            }
            selectedItem.items = null;
            ClearSelectedItemWindow();
        }
        UpdateUI();
    }
    public void RemoveItem(ItemSO item)
    {

    }
    public int EquippedItemIndex()//?
    {
        for (int i = 0; i<equipitems.Length; i++)
        {
            if (equipitems[i].items == null)
                return -1;
            else
            {
                if(equipitems[i].items.equipType == EquipType.Weapon)
                {
                    return 0;
                }
                else if (equipitems[i].items.equipType == EquipType.Top)
                {
                    return 1;
                }
                else if (equipitems[i].items.equipType == EquipType.Bottom)
                {
                    return 2;
                }
            }
                
        }
        return -1;
    }

   
}
