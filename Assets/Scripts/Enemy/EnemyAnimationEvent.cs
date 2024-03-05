using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    private Animator _animator;
    private EnemyController _controller;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponentInParent<EnemyController>();
    }

    public void OnDeadAnimationFinish()
    {
        _controller.Die();
    }

    public void OnEnemyAnimationFinish()
    {
        if (_controller.EnemyData.enemyType == EnemyType.Boss)
        {
            _controller.EnemyAttack.ToggleAttackRange(0, 0, 0, 0);
            _controller.ExitState(EnemyState.Waiting);
            _controller.SetEnemyState(EnemyState.Idle);
        }
        else
        {
            _controller.ExitState(EnemyState.Waiting);
            _controller.SetEnemyState(EnemyState.Idle);
        }
    }

    public void OnEnemyAttackAnimationStart()
    {
        if (_controller.EnemyData.enemyName.Equals("Slime"))
        {
            if (_controller.isChargeAttack)
                _controller.EnemyAttack.ToggleAttackRange(0, 1, 0, 65);
        }
        else
            _controller.EnemyAttack.ToggleAttackRange(0, 0, 1, 65);
    }
}
