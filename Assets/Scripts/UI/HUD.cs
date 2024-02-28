using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class HUD : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryParent;
    public GameObject optionParent;

    private PlayerStats _playerStats { get;  set; }


    [SerializeField] private Slider _playerHpSlider;
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
        
    }

    public void UpdatePlayerHpBar()
    {
        
    }

    public void UpdatePlayerLevelandExpBar()
    {

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



}
