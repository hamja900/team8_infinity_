using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats stats;
    public List<IDamageable> targets = new List<IDamageable>();
    IDamageable curTarget = null;
    int targetIndex;
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable)) // need Fix
        {
            targets.Add(damageable);
            if (curTarget == null)
            {
                curTarget = damageable;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            targets.Remove(damageable);
            if (curTarget == damageable) // 정확히 동작하는지 체크 해야함.
            {
                ChangeTarget();
            }
        }
    }
    void ChangeTarget()
    {
        if (targets.Count == 0)
        {
            curTarget = null;
            return;
        }
        targetIndex++;
        if (targetIndex >= targets.Count)
        {
            targetIndex = 0;
        }
        curTarget = targets[targetIndex];
    }
    public void Attack()
    {
        if (curTarget == null)
        {
            return;
        }
        curTarget.TakeDamage(stats.Attack());
        TuenManager.i.PlayerTurns(stats.AttackSpeed());
    }
}
