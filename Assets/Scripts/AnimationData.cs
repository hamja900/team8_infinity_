using System;
using UnityEngine;

[Serializable]
public class AnimationData
{
    [SerializeField] private string wanderParameterName = "@Wander";
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";

    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string enemyAttackParameterName = "EnemyAttack";
    
    [SerializeField] private string takeDamageParameterName = "@TakeDamage";
    [SerializeField] private string deadParameterName = "Dead";

    public int WanderParameterHash {  get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int EnemyAttackParameterHash { get; private set; }

    public int TakeDamageParameterHash { get; private set; }
    public int DeadParameterHash { get; private set; }

    public void Initialize()
    {
        WanderParameterHash = Animator.StringToHash(wanderParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        EnemyAttackParameterHash = Animator.StringToHash(enemyAttackParameterName);

        TakeDamageParameterHash = Animator.StringToHash(takeDamageParameterName);
        DeadParameterHash = Animator.StringToHash(deadParameterName);
    }
}
