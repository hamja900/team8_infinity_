using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    PlayerStats stats;
    public event Action<bool> PAttackEvent;
    public List<IDamageable> targets = new List<IDamageable>();
    IDamageable curTarget = null;
    int targetIndex;
    bool isAttack = false;
    [SerializeField] RawImage targetUi;
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
                TargetUiUpdate();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            targets.Remove(damageable);
            if (curTarget == damageable)
            {
                ChangeTarget();
                TargetUiUpdate();
            }
        }
    }
    void TargetUiUpdate()
    {
        if (curTarget == null)
        {
            targetUi.enabled = false;
            return;
        }
        targetUi.enabled = true;
        targetUi.transform.position = curTarget.Pos();
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
        TargetUiUpdate();
    }
    public void CanAttack()
    {
        if (curTarget == null || PlayerMove.IsMoveing || isAttack)
        {
            return;
        }
        isAttack = true;
        Vector2 targetPos = curTarget.Pos();
        Vector2 dir = (Vector2)transform.position - targetPos;
        if (dir.x > 0)
        {
            PAttackEvent?.Invoke(true);
            return;
        }
        PAttackEvent?.Invoke(false);
    }
    public void AttackEvent()
    {
        SoundManager.I.Play(SfxIndex.PAttackSound);
        curTarget.TakeDamage(stats.Attack());
        TuenManager.I.PlayerTurns(stats.AttackSpeed());
        isAttack = false;
    }
}
