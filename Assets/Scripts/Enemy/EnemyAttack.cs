using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.PlayerSettings;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController _controller;
    private PlayerGetDmg _playerDamage;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject attackPoint;

    private string _enemyName;

    void Start()
    {
        _controller = GetComponent<EnemyController>();
        _playerDamage = _controller.Target.GetComponent<PlayerGetDmg>();
        _spriteRenderer = attackPoint.GetComponent<SpriteRenderer>();

        _enemyName = _controller.EnemyData.enemyName;
    }

    private void Update()
    {
        Debug.DrawRay(attackPoint.transform.position, Vector3.up * 1.5f);
    }

    public void Attack()
    {
        if (_enemyName.Equals("Slime"))
        {
            if (!_controller.isChargeAttack)
            {
                _controller.EnemyAnimation.TriggerAnimation("Charge");
                ToggleAttackRange(0, 1, 0, 65);
                _controller.ExitState(EnemyState.Attacking);
                _controller.SetEnemyState(EnemyState.Idle);
            }
            else
            {
                _controller.ExitState(EnemyState.Attacking);
                _controller.SetEnemyState(EnemyState.Waiting);
                _controller.EnemyAnimation.TriggerAnimation("Attack");

                Collider2D hit = Physics2D.OverlapBox(attackPoint.transform.position, new Vector2(1.5f, 1.5f), 0, LayerMask.GetMask("Player"));
                if(hit != null) _playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);

                ToggleAttackRange(0, 1, 0, 0);
            }

            _controller.isChargeAttack = !_controller.isChargeAttack;
        }
        else if (_enemyName.Equals("Dragon"))
        {
            if (!_controller.isChargeAttack)
            {
                _controller.EnemyAnimation.TriggerAnimation("Charge");
                ToggleAttackRange(0, 0, 1, 65);
                _controller.ExitState(EnemyState.Attacking);
                _controller.SetEnemyState(EnemyState.Idle);
            }
            else
            {
                _controller.ExitState(EnemyState.Attacking);
                _controller.SetEnemyState(EnemyState.Waiting);
                _controller.EnemyAnimation.TriggerAnimation("Attack");

                Collider2D hit = Physics2D.OverlapBox(attackPoint.transform.position, new Vector2(3.5f, 3.5f), 0, LayerMask.GetMask("Player"));
                if (hit != null) _playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);

                ToggleAttackRange(0, 0, 1, 0);
            }

            _controller.isChargeAttack = !_controller.isChargeAttack;
        }
        else
        {
            _playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);
            _controller.ExitState(EnemyState.Attacking);
            _controller.SetEnemyState(EnemyState.Waiting);
        }
    }

    public void ToggleAttackRange(float r, float g, float b, float a)
    {
        _spriteRenderer.color = new Color(r, g, b, a);
    }
}
