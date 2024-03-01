using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Equip : MonoBehaviour
{


    public void EquipItem(int index)
    {
        ItemSlot item = Inventory.instance.slots[index];

        if (item.items.equipType == EquipType.Weapon)
        {
            if (Inventory.instance.equipitems[0].items != null)
            {
                UnEquipItem(index, 0);
                Inventory.instance.equipUiSlots[0].Set(item, index);
                Inventory.instance.equipitems[0].items = Inventory.instance.slots[index].items;
            }

            Inventory.instance.equipUiSlots[0].Set(item, index);
            Inventory.instance.equipitems[0].items = Inventory.instance.slots[index].items;

        }
        else if (item.items.equipType == EquipType.Top)
        {
            if (Inventory.instance.equipitems[1].items != null)
            {
                UnEquipItem(index, 1);
                Inventory.instance.equipUiSlots[1].Set(item, index);
                Inventory.instance.equipitems[1].items = Inventory.instance.slots[index].items;
            }

            Inventory.instance.equipUiSlots[1].Set(item, index);
            Inventory.instance.equipitems[1].items = Inventory.instance.slots[index].items;
        }


        else if (item.items.equipType == EquipType.Bottom)
        {
            if (Inventory.instance.equipitems[2].items != null)
            {
                UnEquipItem(index, 2);
                Inventory.instance.equipUiSlots[2].Set(item, index);
                Inventory.instance.equipitems[2].items = Inventory.instance.slots[index].items;
            }

            Inventory.instance.equipUiSlots[2].Set(item, index);
            Inventory.instance.equipitems[2].items = Inventory.instance.slots[index].items;


        }
        Inventory.instance.UpdateButtons();
        Inventory.instance.uiSlots[index].isEquipped = true;
        UpdateEquipUI();
        

    }
    public void UnEquipItem(int index, int slotIndex)
    {
        if (index == -1)
            return;
        if (Inventory.instance.equipUiSlots[slotIndex].index == -1)
        {
            Inventory.instance.equipUiSlots[slotIndex].Clear();
            Inventory.instance.equipUiSlots[slotIndex].icon.gameObject.SetActive(false);
            UpdateEquipUI();
            return;
        }
        Inventory.instance.uiSlots[Inventory.instance.equipUiSlots[slotIndex].index].isEquipped = false;
        Inventory.instance.equipUiSlots[slotIndex].Clear();
        Inventory.instance.equipUiSlots[slotIndex].icon.gameObject.SetActive(false);
        UpdateEquipUI();
    }


    private void UpdateEquipUI()
    {
        for (int i = 0; i < Inventory.instance.slots.Length; i++)
        {
            if (Inventory.instance.uiSlots[i].isEquipped)
            {
                Inventory.instance.uiSlots[i].equipMark.SetActive(true);
            }
            else
            {
                Inventory.instance.uiSlots[i].equipMark.SetActive(false);
            }
        }
    }

}
