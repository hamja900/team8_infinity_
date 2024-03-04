using UnityEngine;
using UnityEngine.InputSystem.XR;

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
        if (_controller.EnemyData.enemyName.Equals("Slime"))
        {
            _controller.ExitState(EnemyState.Waiting);
            _controller.SetEnemyState(EnemyState.Idle);
        }
        else
        {
            _controller.ExitState(EnemyState.Waiting);
            _controller.SetEnemyState(EnemyState.Idle);
        }
    }
}
