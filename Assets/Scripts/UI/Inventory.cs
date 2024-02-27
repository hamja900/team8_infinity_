using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public ItemSO testItem; ///테스트용장비

    public ItemSlotUI[] uiSlot;
    public ItemSlot[] slots;
    public EquipSlotUI[] equipUiSlot;
    public ItemSlot[] equipSlots = new ItemSlot[3];

    public GameObject inventoryPopup;
    public Transform dropPosition;

    [Header("SelectedItem")]
    private ItemSlot _selectedItem;
    private int _selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatName;
    public TextMeshProUGUI selectedItemStatValue;
    public GameObject useButton;
    public GameObject dropButton;
    public GameObject equipButton;
    public GameObject unEquipButton;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        slots = new ItemSlot[uiSlot.Length];
        equipSlots = new ItemSlot[equipUiSlot.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlot[i].index = i;
            uiSlot[i].Clear();
        }
        for (int j = 0; j< equipSlots.Length;j++)
        {
            equipSlots[j] = new ItemSlot();
            equipUiSlot[j].idx = j;
            equipUiSlot[j].Clear();
        }
        AddItem(testItem);

        ClearSelectedItemWindow();
        CheckEquip();
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
        Instantiate(item.dropPrefab, dropPosition.position, Quaternion.Euler(Vector2.zero));
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items != null)
                uiSlot[i].Set(slots[i]);
            else
                uiSlot[i].Clear();
        }
    }



    private ItemSlot GetItemStack(ItemSO item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].items == item && slots[i].quantity < item.maxStack)
            {
                return slots[i];
            }

        }
        return null;
    }

    private ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
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

        _selectedItem = slots[index];
        _selectedItemIndex = index;

        selectedItemName.text = _selectedItem.items.itemName;
        selectedItemDescription.text = _selectedItem.items.itemDescription;

        if (_selectedItem.items.itemType == ItemType.Expendable)
        {
            switch (_selectedItem.items.expendType)
            {
                case ExpendType.Heal:
                    {
                        selectedItemStatName.text = "HP회복";
                        selectedItemStatValue.text = _selectedItem.items.healPoint.ToString();
                    }
                    break;
                case ExpendType.Hunger:
                    {
                        selectedItemStatName.text = "포만도";
                        selectedItemStatValue.text = _selectedItem.items.HungerPoint.ToString();
                    }
                    break;
                default:
                    {
                        selectedItemStatName.text = string.Empty;
                        selectedItemStatValue.text = string.Empty;
                    }
                    break;
            }
        }
        else if (_selectedItem.items.itemType == ItemType.Equipable)
        {
            switch (_selectedItem.items.equipType)
            {
                case EquipType.Weapon:
                    {
                        selectedItemStatName.text = "공격력";
                        selectedItemStatValue.text = _selectedItem.items.atk.ToString();
                    }
                    break;
                case EquipType.Top:
                    {
                        selectedItemStatName.text = "방어도";
                        selectedItemStatValue.text = _selectedItem.items.def.ToString();
                    }
                    break;
                case EquipType.Bottom:
                    {
                        selectedItemStatName.text = "방어도";
                        selectedItemStatValue.text = _selectedItem.items.def.ToString();
                    }
                    break;
                default:
                    {
                        selectedItemStatName.text = string.Empty;
                        selectedItemStatValue.text = string.Empty;
                    }
                    break;
            }
        }

        useButton.SetActive(_selectedItem.items.itemType == ItemType.Expendable);
        equipButton.SetActive(_selectedItem.items.isEquipped == false && _selectedItem.items.itemType == ItemType.Equipable);
        unEquipButton.SetActive(_selectedItem.items.isEquipped == true && _selectedItem.items.itemType == ItemType.Equipable);
        dropButton.SetActive(true);



    }

    private void ClearSelectedItemWindow()
    {
        _selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;

        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void OnUseButton()
    {
        if (_selectedItem.items.itemType == ItemType.Expendable)
        {
            switch (_selectedItem.items.expendType)
            {
                case ExpendType.Heal:
                    {

                    }
                    break;
                case ExpendType.Hunger:
                    {

                    }
                    break;
            }
        }
    }

    public void OnEquipButton()
    {
        _selectedItem.items.isEquipped = true;
        Equip(_selectedItemIndex);
    }
    private void Equip(int index)
    {
        if (slots[index].items == null)
            return;
        if (slots[index].items.itemType == ItemType.Equipable && slots[index].items.isEquipped)
        {
            if (slots[index].items.equipType == EquipType.Weapon)
            {
                if (equipSlots[0] != null)
                {
                    equipSlots[0].items = slots[index].items;
                    equipUiSlot[0].Set(equipSlots[0].items);
                }
            }
            else if (slots[index].items.equipType == EquipType.Top)
            {
                if (equipSlots[1] != null)
                {
                    equipSlots[1].items = slots[index].items;
                    equipUiSlot[1].Set(equipSlots[1].items);
                }
            }
            else if (slots[index].items.equipType == EquipType.Bottom)
            {
                if (equipSlots[2] != null)
                {
                    equipSlots[2].items = slots[index].items;
                    equipUiSlot[2].Set(equipSlots[2].items);
                }
            }
        }
        UpdateEquipSlotUI();
        uiSlot[index].Clear();
    }
    public void OnUnEquipButton()
    {
        _selectedItem.items.isEquipped = false;
        UnEquip(_selectedItemIndex);
    }
    private void UnEquip(int index)
    {
        UpdateEquipSlotUI();
    }
    public void UpdateEquipSlotUI()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (equipSlots[i] != null)
            {
                equipUiSlot[i].icon.sprite = equipSlots[i].items.itemSprite;
            }
            else
            {
                equipUiSlot[i].icon.gameObject.SetActive(false);
            }
        }
    }
    public void CheckEquip()
    {
        for(int i = 0; i<slots.Length; i++)
        {
            if (!slots[i].items.isEquipped)
            {
                uiSlot[i].Clear();
                return;
            }
            else if (slots[i].items.isEquipped)
            {
                Equip(i);
            }
        }
        UpdateEquipSlotUI();
    }

    public void OnDropButton()
    {

    }

    public void OnCloseInventoryButton()
    {
        inventoryPopup.gameObject.SetActive(false);
    }
}
