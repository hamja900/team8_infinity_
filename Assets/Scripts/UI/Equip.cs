using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Equip : MonoBehaviour
{
   public void EquipItem(int index)
    {
        ItemSlot item = Inventory.instance.slots[index];
        if(item.items.equipType == EquipType.Weapon)
        {
            Inventory.instance.equipUiSlots[0].Set(item);
        }
        else if (item.items.equipType == EquipType.Top)
        {
            Inventory.instance.equipUiSlots[1].Set(item);
        }
        else if (item.items. equipType == EquipType.Bottom)
        {
            Inventory.instance.equipUiSlots[2].Set(item);
        }
        Inventory.instance.uiSlots[index].isEquipped = true;
        UpdateEquipUI();

    }
    public void UnEquipItem(int index)
    {
    }

    private void UpdateEquipUI()
    {
        
    }

}
