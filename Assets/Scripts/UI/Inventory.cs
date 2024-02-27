using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemSlot
{
    public ItemSO items;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlot;
    public ItemSlot[] slots;
    public GameObject weaponSlot;                   //  여기부터
    public UnityEngine.UI.Image weaponImage;
    public GameObject topSlot;
    public UnityEngine.UI.Image topImage;
    public GameObject bottomSlot;
    public UnityEngine.UI.Image bottomImage;       //여기까지 장착 UI


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

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlot[i].index = i;
            uiSlot[i].Clear();
        }

        //clearSelectedItemWindow()
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


    public void SetEquipment(ItemSO item)
    {
        if (item.isEquipped)
        {
            switch (item.equipType)
            {
                case EquipType.Weapon:
                    {
                        weaponImage.gameObject.SetActive(true);
                        weaponImage.sprite = item.itemSprite;
                    }
                    break;
                case EquipType.Top:
                    {
                        weaponImage.gameObject.SetActive(true);
                        weaponImage.sprite = item.itemSprite;
                    }
                    break;
                case EquipType.Bottom:
                    {
                        weaponImage.gameObject.SetActive(true);
                        weaponImage.sprite = item.itemSprite;
                    }
                    break;
            }

        }

    }

    public void OnUseButton()
    {
        if(_selectedItem.items.itemType == ItemType.Expendable)
        {
            switch(_selectedItem.items.expendType)
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

    }
    public void OnUnEquipButton()
    {

    }
    void UnEquip(int index)
    {

    }

    public void OnDropButton()
    {

    }

    public void OnCloseInventoryButton()
    {
        inventoryPopup.gameObject.SetActive(false);
    }
}
