using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController _controller;
    private PlayerGetDmg _playerDamage;

    void Start()
    {
        _controller = GetComponent<EnemyController>();
        _playerDamage = _controller.Target.GetComponent<PlayerGetDmg>();
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("Player Attack");
        
        _playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);
        _controller.ExitState(EnemyState.Attacking);
        _controller.SetEnemyState(EnemyState.Idle);
    }
}
