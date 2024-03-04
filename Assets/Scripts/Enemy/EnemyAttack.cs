using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController _controller;
    private PlayerGetDmg _playerDamage;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject attackPoint;
    private Vector3 attackPos;

    private string _enemyName;

    void Start()
    {
        _controller = GetComponent<EnemyController>();
        _playerDamage = _controller.Target.GetComponent<PlayerGetDmg>();
        _spriteRenderer = attackPoint.GetComponent<SpriteRenderer>();

        _enemyName = _controller.EnemyData.enemyName;
    }

    public void Attack()
    {
        if (_enemyName.Equals("Slime"))
        {
            if (!_controller.isChargeAttack)
            {
                Debug.Log("Charge");
                _spriteRenderer.color = new Color(0, 1, 0, 65);
                //attackPoint.transform.parent = null;
                //attackPoint.transform.position = attackPos;
                _controller.ExitState(EnemyState.Attacking);
                _controller.SetEnemyState(EnemyState.Idle);
            }
            else
            {
                Debug.Log("Slime Attack");
                _controller.EnemyAnimation.ToggleAnimation("Charge", false);
                _controller.EnemyAnimation.ToggleAnimation("Attack", true);
                // TODO : Player가 범위 내에 있었으면 데미지 주기
                RaycastHit2D hit = Physics2D.BoxCast(attackPoint.transform.position, new Vector2(3, 3), 0, Vector2.zero, LayerMask.GetMask("Player"));
                if(hit.transform != null) _playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);

                _controller.EnemyAnimation.ToggleAnimation("Attack", false);
                attackPoint.transform.parent = _controller.transform;
                _spriteRenderer.color = new Color(0, 1, 0, 0);
            }

            _controller.isChargeAttack = !_controller.isChargeAttack;
        }
        else
        {
            _playerDamage.TakeDamage(_controller.EnemyData.enemyAtk);
        }

        //_controller.ExitState(EnemyState.Attacking);
        //_controller.SetEnemyState(EnemyState.Idle);
    }
}
