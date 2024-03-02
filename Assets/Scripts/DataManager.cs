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
    
    //public ItemSlot[] slots = new ItemSlot[Inventory.instance.slots.Length];
    //public ItemSlot[] equipitems = new ItemSlot[Inventory.instance.equipitems.Length];

    //public ItemSlot[] hotKey = new ItemSlot[HUD.instance.hotKey.Length];
}
public class DataManager : SingletoneBase<DataManager>
{
    public SaveData saveData;

    private string path;

    private PlayerStats playerStats;


    void Start()
    {
        path = Path.Combine(Application.dataPath,"database.json");
        playerStats = HUD.instance.player.GetComponent<PlayerStats>();
    }

    public void JsonLoad()
    {
        path = Path.Combine(Application.dataPath,"database.json");

        if (!File.Exists(path))
        {
           
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            //saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData == null)
            {
                if (saveData != null)
                {
                    //for (int i = 0; i < saveData.slots.Length; i++)
                    //{
                    //    Inventory.instance.AddItem(saveData.slots[i].items);
                    //}
                }
                //if (saveData.equipitems != null)
                //{
                //    //for (int j = 0; j < saveData.equipitems.Length; j++)
                //    //{
                //    //    Inventory.instance.equipitems[j].items = saveData.equipitems[j].items;
                //    //}
                //}
                //if (saveData.hotKey != null)
                //{
                //    //for (int k = 0; k < saveData.hotKey.Length; k++)
                //    //{
                //    //    HUD.instance.hotKey[k].items = saveData.hotKey[k].items;
                //    //}
                //}
                playerStats.hp = saveData.hp;
                playerStats.maxHp = saveData.maxHp;
                playerStats.hunger = JsonUtility.FromJson<SaveData>(loadJson).hunger;
                playerStats.maxHunger = saveData.maxHunger;
                playerStats.exp = saveData.exp;
                playerStats.maxExp = saveData.maxExp;
                playerStats.level = saveData.level;
            }
        }
    }
    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        //for (int i = 0; i < Inventory.instance.slots.Length; i++)
        //{
        //    saveData.slots[i] = new ItemSlot();
        //    saveData.slots[i] = Inventory.instance.slots[i];
        //}
        //for (int j = 0; j < Inventory.instance.equipitems.Length; j++)
        //{
        //    saveData.equipitems[j] = new ItemSlot();
        //    saveData.equipitems[j] = Inventory.instance.equipitems[j];
        //}
        //for (int k = 0; k < HUD.instance.hotKey.Length; k++)
        //{
        //    saveData.hotKey[k] = new ItemSlot();
        //    saveData.hotKey[k] = HUD.instance.hotKey[k];
        //}
        saveData.hp = playerStats.hp;
        saveData.maxHp = playerStats.maxHp;
        saveData.hunger = playerStats.hunger;
        saveData.maxHunger = playerStats.maxHunger;
        saveData.exp = playerStats.exp;
        saveData.maxExp = playerStats.maxExp;
        saveData.level = playerStats.level;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);

    }
}
