using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject player { get; private set; }

    private PlayerStats _playerStats { get;  set; }


    [SerializeField] private Slider _playerHpSlider { get; set; }
    [SerializeField] private Slider _playerExpSlider { get; set; }
    [SerializeField] private Text _levelText { get; set; }
    [SerializeField] private Text _dungeonLevelText { get; set; }

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
