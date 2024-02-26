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

    private PlayerStats _playerStats { get;  set; }


    [SerializeField] private Slider _playerHpSlider;
    [SerializeField] private Slider _playerExpSlider;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _dungeonLevelText;

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



}
