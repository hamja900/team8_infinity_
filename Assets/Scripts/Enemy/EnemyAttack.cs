using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController _controller;
    private PlayerGetDmg _playerDamage;

    private void Awake()
    {
        _controller = GetComponent<EnemyController>();
        //_playerDamage = _controller.Target.gameObject.GetComponent<PlayerGetDmg>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("Player Attack");
        //_controller.EnemyAnimation
        //_playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);
        _controller.ExitState(EnemyState.Attacking);
        _controller.SetEnemyState(EnemyState.Idle);
    }
}
