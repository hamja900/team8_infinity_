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
        damage -= stats.GetDef();
        if (damage <= 0)
        {
            damage = 0;
        }
        stats.GetDmg(damage);
    }

    public Vector2 Pos()
    {
        return (Vector2)transform.position;
    }
}
