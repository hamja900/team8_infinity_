using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Equip : MonoBehaviour
{
    //public int[] equipIndex;

    public void EquipItem(int index)
    {
        int[] equipIndex = new int[3];


        ItemSlot item = Inventory.instance.slots[index];

        if (item.items.equipType == EquipType.Weapon)
        {
            if (Inventory.instance.equipitems[0].items != null)
            {
                UnEquipItem(equipIndex[0], 0);

            }
            equipIndex[0] = index;
            Inventory.instance.slots[index].isEquipped = true;
            Inventory.instance.equipUiSlots[0].Set(item, index);
            Inventory.instance.equipitems[0].items = Inventory.instance.slots[index].items;

        }
        else if (item.items.equipType == EquipType.Top)
        {
            if (Inventory.instance.equipitems[1].items != null)
            {
                UnEquipItem(equipIndex[1], 1);
            }
            equipIndex[1] = index;
            Inventory.instance.slots[index].isEquipped = true;
            Inventory.instance.equipUiSlots[1].Set(item, index);
            Inventory.instance.equipitems[1].items = Inventory.instance.slots[index].items;
        }


        else if (item.items.equipType == EquipType.Bottom)
        {
            if (Inventory.instance.equipitems[2].items != null)
            {
                UnEquipItem(equipIndex[2], 2);
                
            }
            equipIndex[2] = index;
            Inventory.instance.slots[index].isEquipped = true;
            Inventory.instance.equipUiSlots[2].Set(item, index);
            Inventory.instance.equipitems[2].items = Inventory.instance.slots[index].items;


        }
        Inventory.instance.UpdateButtons();
        Inventory.instance.slots[index].isEquipped = true;
        UpdateEquipMark();
        

    }
    public void UnEquipItem(int index, int slotIndex)
    {
        if (index == -1)
            return;
        if (Inventory.instance.equipUiSlots[slotIndex].index == -1)
        {
            Inventory.instance.equipUiSlots[slotIndex].Clear();
            Inventory.instance.equipUiSlots[slotIndex].icon.gameObject.SetActive(false);
            Inventory.instance.slots[index].isEquipped = false;
            UpdateEquipMark();
            return;
        }
        //Inventory.instance.uiSlots[Inventory.instance.equipUiSlots[slotIndex].index].isEquipped = false;
        Inventory.instance.slots[index].isEquipped = false;
        Inventory.instance.equipitems[slotIndex].items = null;
        Inventory.instance.equipUiSlots[slotIndex].Clear();
        Inventory.instance.equipUiSlots[slotIndex].icon.gameObject.SetActive(false);
        
        UpdateEquipMark();
    }
    public void UpdateEquipUI()
    {
        for(int i = 0; i< Inventory.instance.equipUiSlots.Length; i++)
        {
            if (Inventory.instance.equipitems[i].items != null)
            {
                Inventory.instance.equipUiSlots[i].Set(Inventory.instance.equipitems[i], i);
            }
        }
    }

    public void UpdateEquipMark()
    {
        for (int i = 0; i < Inventory.instance.slots.Length; i++)
        {
            if (Inventory.instance.slots[i].isEquipped)
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
