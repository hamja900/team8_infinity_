using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats stats;
    public event Action PAttackEvent;
    public List<IDamageable> targets = new List<IDamageable>();
    IDamageable curTarget = null;
    int targetIndex;
    bool isAttack = false;
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
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
    public void ChangeTarget()
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
    public void CanAttack()
    {
        if (curTarget == null || PlayerMove.IsMoveing || isAttack)
        {
            return;
        }
        isAttack = true;
        PAttackEvent?.Invoke();
    }
    public void AttackEvent()
    {
        curTarget.TakeDamage(stats.Attack());
        TuenManager.I.PlayerTurns(stats.AttackSpeed());
        isAttack = false;
    }
}
