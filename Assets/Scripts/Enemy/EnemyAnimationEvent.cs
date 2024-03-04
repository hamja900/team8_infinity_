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
        _controller.ExitState(EnemyState.Attacking);
        _controller.SetEnemyState(EnemyState.Idle);
    }
}
