using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDmg : MonoBehaviour, IDamageable
{
    PlayerStats stats;
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }
    public void TakeDamage(int damage)
    {
        //damage 방어력 적용해야함
        stats.GetDmg(damage);
    }
}
