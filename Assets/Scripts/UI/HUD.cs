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

    private PlayerStats _playerStats { get;  set; }


    [SerializeField] private Slider _playerHpSlider;
    [SerializeField] private Slider _playerHungerSlider;
    [SerializeField] private Slider _playerExpSlider;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _dungeonLevelText;

    public GameObject inventory;
    public GameObject option;

    private void Awake()
    {
        _playerStats = player.GetComponent<PlayerStats>();
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
        Inventory.instance.itemResisterMode = true;
        OnInventoryButton();
    }

    public void ReadyToItemUse()
    {
        throw new NotImplementedException();
    }

    public void OnHotKeyButtons()
    {
        
    }

}
