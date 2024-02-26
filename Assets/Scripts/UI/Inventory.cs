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
    public Button useButton;
    public Button dropButton;
    public Button equipButton;
    public Button unEquipButton;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        slots = new ItemSlot[uiSlot.Length];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlot[i].index = i;
            uiSlot[i].Clear();
        }

      //clearSelectedItemWindow()
    }


    public void AddItem(ItemSO item)
    {

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
}
