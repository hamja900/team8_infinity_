using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats stats;
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
