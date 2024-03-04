using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem.EnhancedTouch;
using System.Net;
using Unity.VisualScripting;


[System.Serializable]
public class SaveData
{
    public float hp;
    public float maxHp;
    public float hunger;
    public float maxHunger;
    public float exp;
    public float maxExp;
    public int level;
    public int dungeonLevel;

    public ItemSlot[] slots = new ItemSlot[Inventory.instance.slots.Length];
    public ItemSlot[] equipitems = new ItemSlot[Inventory.instance.equipitems.Length];
    public ItemSlot[] hotKey = new ItemSlot[HUD.instance.hotKey.Length];
    //public ItemSlotUI[] uiSlots = new ItemSlotUI[Inventory.instance.uiSlots.Length];
    //public QuickSlotsUI[] quickSlotUi = new QuickSlotsUI[HUD.instance.quickUI.Length];
}
public class DataManager : SingletoneBase<DataManager>
{
    public SaveData saveData;
    private string path;

    private PlayerStats playerStats;


    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        playerStats = HUD.instance.player.GetComponent<PlayerStats>();
    }

    IEnumerator WaitForThreeTime()
    {
        yield return null;
        if (!File.Exists(path))
        {
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {

                for (int i = 0; i < saveData.slots.Length; i++)
                {
                    Inventory.instance.slots[i] = saveData.slots[i];
                    Inventory.instance.slots[i].isEquipped = saveData.slots[i].isEquipped;
                }

                for (int j = 0; j < saveData.equipitems.Length; j++)
                {
                    Inventory.instance.equipitems[j] = saveData.equipitems[j];

                    
                }

                for (int k = 0; k < saveData.hotKey.Length; k++)
                {
                    HUD.instance.hotKey[k] = saveData.hotKey[k];
                   
                }

                //for (int i = 0; i< saveData.uiSlots.Length; i++)
                //{
                //    Inventory.instance.uiSlots[i] = saveData.uiSlots[i];
                //}
                //for (int i = 0; i< saveData.quickSlotUi.Length; i++)
                //{
                //    HUD.instance.quickUI[i] = saveData.quickSlotUi[i];
                //}
                HUD.instance.UpdateQuickSlotUI();
                Inventory.instance.UpdateUI();
                Inventory.instance.equipScript.UpdateEquipMark();
                Inventory.instance.equipScript.UpdateEquipUI();
                

                playerStats.hp = saveData.hp;
                playerStats.maxHp = saveData.maxHp;
                playerStats.hunger = saveData.hunger;
                playerStats.maxHunger = saveData.maxHunger;
                playerStats.exp = saveData.exp;
                playerStats.maxExp = saveData.maxExp;
                playerStats.level = saveData.level;
                GameManager.I.clearRoomNum = saveData.dungeonLevel;
            }
        }

    }
    public void JsonLoad()
    {

        StartCoroutine(WaitForThreeTime());
      
    }
    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i < Inventory.instance.slots.Length; i++)
        {
            saveData.slots[i] = new ItemSlot();
            saveData.slots[i] = Inventory.instance.slots[i];
            saveData.slots[i].isEquipped = Inventory.instance.slots[i].isEquipped;
        }
        for (int j = 0; j < Inventory.instance.equipitems.Length; j++)
        {
            saveData.equipitems[j] = new ItemSlot();
            saveData.equipitems[j] = Inventory.instance.equipitems[j];
          
        }
        for (int k = 0; k < HUD.instance.hotKey.Length; k++)
        {
            saveData.hotKey[k] = new ItemSlot();
            saveData.hotKey[k] = HUD.instance.hotKey[k];
        }
        //for( int i = 0; i<Inventory.instance.uiSlots.Length; i++)
        //{
        //    saveData.uiSlots[i] = new ItemSlotUI();
        //    saveData.uiSlots[i] = Inventory.instance.uiSlots[i];
        //}
        //for(int i = 0; i<HUD.instance.quickUI.Length; i++)
        //{
        //    saveData.quickSlotUi[i] = new QuickSlotsUI();
        //    saveData.quickSlotUi[i] = HUD.instance.quickUI[i];
        //}
        saveData.hp = playerStats.hp;
        saveData.maxHp = playerStats.maxHp;
        saveData.hunger = playerStats.hunger;
        saveData.maxHunger = playerStats.maxHunger;
        saveData.exp = playerStats.exp;
        saveData.maxExp = playerStats.maxExp;
        saveData.level = playerStats.level;
        saveData.dungeonLevel = GameManager.I.clearRoomNum;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);

    }
}
