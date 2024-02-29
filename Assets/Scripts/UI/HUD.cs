using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

[Serializable]
public class HUD : MonoBehaviour
{
    public QuickSlotsUI[] quickUI;
    public ItemSlot[] hotKey;

    public GameObject player;
    public GameObject inventoryParent;
    public GameObject optionParent;
    public GameObject UseItemConfirm;
    public UnityEngine.UI.Image confirmIcon;

    public int previousSelectedHotKeyIndex = -1;

    private PlayerStats _playerStats { get;  set; }


    [SerializeField] private Slider _playerHpSlider;
    [SerializeField] private Slider _playerHungerSlider;
    [SerializeField] private Slider _playerExpSlider;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _dungeonLevelText;

    public GameObject inventory;
    public GameObject option;

    public static HUD instance;

    private void Awake()
    {
        _playerStats = player.GetComponent<PlayerStats>();
        instance = this;
    }
    private void Start()
    {
        hotKey = new ItemSlot[quickUI.Length];
        for (int k = 0; k < quickUI.Length; k++)
        {
            hotKey[k] = new ItemSlot();
            quickUI[k].index = k;
            quickUI[k].Clear();
        }
        UpdatePlayerHpBar();
        UpdatePlayerLevelandExpBar();
        UpdatePlayerHungerBar();
        //TuenManager.I.MonsterTurn += UpdatePlayerHpBar;
    }

    private void Update()
    {
        UpdatePlayerHpBar();
        UpdatePlayerHungerBar();
    }

    public void UpdatePlayerHpBar()
    {
        _playerHpSlider.value = _playerStats.hp / _playerStats.maxHp;
    }

    public void UpdatePlayerLevelandExpBar()
    {
        _levelText.text = "Lv."+_playerStats.level.ToString();
        _playerExpSlider.value = _playerStats.exp / _playerStats.maxExp;
    }
    public void UpdatePlayerHungerBar()
    {
        _playerHungerSlider.value = _playerStats.hunger / _playerStats.maxHunger;
    }
    public void UpdateDungeonLevel()
    {

    }

    public void OnNextTurnButton()
    {
        UpdatePlayerHpBar();
        
    }
    public void OnInvestigateButton()
    {

    }
    public void OnOptionButton()
    {
        try
        {
            optionParent.transform.GetChild(0).gameObject.SetActive(true);
        }
        catch
        {
            Instantiate(option, inventoryParent.transform);
        }
    }
    public void OnInventoryButton()
    {
        try
        {
            inventoryParent.transform.GetChild(0).gameObject.SetActive(true);
        }
        catch
        {
            Instantiate(inventory,inventoryParent.transform);
        }
    }

    public void ResisterHotKey()
    {
        try
        {
            inventoryParent.transform.GetChild(0).gameObject.SetActive(true);
        }
        catch
        {
            Instantiate(inventory, inventoryParent.transform);
        }
        Inventory.instance.itemResisterMode = true;
    }

    public void UpdateQuickSlotUI()
    {
        for(int i = 0; i < quickUI.Length; i++)
        {
            if (hotKey[i].items == null)
            {
                quickUI[i].Clear();
            }
        }
    }

    public void OnUseConfirmUIButton()
    {
        switch (hotKey[previousSelectedHotKeyIndex].items.expendType)
        {
            case ExpendType.Heal:
                {
                    _playerStats.HealHp(hotKey[previousSelectedHotKeyIndex].items.healPoint);
                }
                break;
            case ExpendType.Cure:
                {

                }
                break;
            case ExpendType.Hunger:
                {
                    _playerStats.EatFood(hotKey[previousSelectedHotKeyIndex].items.HungerPoint);
                }
                break;
        }
        hotKey[previousSelectedHotKeyIndex].items = null;
        UpdateQuickSlotUI();
    }
}
