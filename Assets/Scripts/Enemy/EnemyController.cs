using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Waiting,
    Dead
}

public class EnemyController : MonoBehaviour, IDamageable
{
    [field: Header("Stats")]
    [field: SerializeField] public EnemySO EnemyData { get; private set; }

    public EnemyMove EnemyMove { get; private set; }
    public EnemyAttack EnemyAttack { get; private set; }
    public EnemyAnimation EnemyAnimation { get; private set; }
    public EnemyPathFind EnemyPathFind { get; private set; }

    public Transform Target { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }

    public Transform movePoint;
    public float moveSpeed = 5f;

    public bool isEnemyTurn = false;
    public bool isTurnOver = false;
    public bool isChargeAttack = false;

    public EnemyState currentState;

    public int localTurn;
    [SerializeField] private int currentHealth;

    public event Action OnDie;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody = GetComponent<Rigidbody>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        EnemyMove = GetComponent<EnemyMove>();
        EnemyAttack = GetComponent<EnemyAttack>();
        EnemyAnimation = GetComponent<EnemyAnimation>();
        EnemyPathFind = GetComponent<EnemyPathFind>();

        currentHealth = EnemyData.enemyMaxHealth;
    }

    void Start()
    {
        movePoint.parent = null;
        localTurn = 0;

        TuenManager.I.MonsterTurn += UpdateEnemyTurn;
    }

    void Update()
    {
        if (isEnemyTurn)
        {
            UpdateState();
        }           
    }

    public void SetEnemyState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Idle:
                currentState = EnemyState.Idle;
                EnemyAnimation.ToggleAnimation("Idle", true);
                break;
            case EnemyState.Chasing:
                if (isChargeAttack)
                {
                    currentState = EnemyState.Attacking;
                    SetEnemyState(EnemyState.Attacking);
                    return;
                }
                else
                {
                    currentState = EnemyState.Chasing;
                    EnemyAnimation.ToggleAnimation("Walk", true);
                }
                break;
            case EnemyState.Attacking: 
                currentState = EnemyState.Attacking;
                if (EnemyData.enemyName.Equals("Slime"))
                {
                    Debug.Log("Slime Attack");
                }
                else
                    EnemyAnimation.TriggerAnimation("EnemyAttack");
                break;
            case EnemyState.Waiting:
                currentState = EnemyState.Waiting;
                EnemyAnimation.ToggleAnimation("Idle", true);
                break;
            case EnemyState.Dead:
                currentState = EnemyState.Dead;
                break;
        }
    }

    public void ExitState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Idle:
                currentState = EnemyState.Idle;
                EnemyAnimation.ToggleAnimation("Idle", false);
                break;
            case EnemyState.Chasing:
                currentState = EnemyState.Idle;
                EnemyAnimation.ToggleAnimation("Walk", false);
                break;
            case EnemyState.Attacking:
                currentState = EnemyState.Idle;
                break;
            case EnemyState.Waiting:
                currentState = EnemyState.Idle;
                break;
        }
    }

    public void UpdateState()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                CheckPlayerInRange();
                break;
            case EnemyState.Chasing:
                EnemyMove.Move();
                break;
            case EnemyState.Attacking:
                EnemyAttack.Attack();
                break;
            case EnemyState.Waiting:
                break;
        }
    }

    private void CheckPlayerInRange()
    {
        if (IsInAttackRange())
        {
            if (!IsTurnOver(EnemyState.Attacking))
            {
                SetEnemyState(EnemyState.Attacking);
            }
            else
                return;
        }
        else if (IsInChasingRange())
        {
            if (Target.transform.position.x - transform.position.x < 0) SpriteRenderer.flipX = true;
            else SpriteRenderer.flipX = false;

            if (!IsTurnOver(EnemyState.Chasing))
                SetEnemyState(EnemyState.Chasing);
            else
                return;
        }
        else
        {
            localTurn = 0;
            EndOfEnemyTurn();
            return;
        }
    }

    private bool IsInChasingRange()
    {
        float playerDistanceSqr = (Target.transform.position - transform.position).sqrMagnitude;
        return playerDistanceSqr <= EnemyData.enemyDetectRange * EnemyData.enemyDetectRange;
    }

    private bool IsInAttackRange()
    {
        float playerDistanceSqr = (Target.transform.position - transform.position).sqrMagnitude;
        return playerDistanceSqr <= EnemyData.enemyAttackRange * EnemyData.enemyAttackRange;
    }

    private void UpdateEnemyTurn(int turn)
    {
        movePoint.parent = null;
        movePoint.position = EnemyPathFind.SetEnemyMovePoint();

        localTurn += turn;
        isEnemyTurn = true;

        SetEnemyState(EnemyState.Idle);
    }

    public bool IsTurnOver(EnemyState state)
    {
        switch(state)
        {
            case EnemyState.Chasing:
                if(localTurn < EnemyData.enemyMoveCost)
                {
                    EndOfEnemyTurn();
                    return true;
                }
                localTurn -= EnemyData.enemyMoveCost;
                movePoint.position = EnemyPathFind.SetEnemyMovePoint();
                return false;
            case EnemyState.Attacking:
                if(localTurn < EnemyData.enemyAttackCost)
                {
                    EndOfEnemyTurn();
                    return true;
                }
                localTurn -= EnemyData.enemyAttackCost;
                return false;
                default: return false;
        }
    }

    public void EndOfEnemyTurn()
    {
        movePoint.parent = gameObject.transform;
        EnemyPathFind.OnEnemyTurnOver();

        TuenManager.I.EnemyTurnOver();
        isEnemyTurn = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            EnemyAnimation.TriggerAnimation("Dead");
            //Die();
            return;
        }
        EnemyAnimation.TriggerAnimation("TakeDamage");
        if(isChargeAttack)
        {
            isChargeAttack = false;
            EnemyAttack.ToggleAttackRange(0, 0, 0, 0);
            ExitState(EnemyState.Attacking);
            SetEnemyState(EnemyState.Waiting);
            EndOfEnemyTurn();
        }
    }

    public Vector2 Pos()
    {
        return (Vector2)transform.position;
    }

    public void Die()
    {
        //if (currentHealth > 0) return;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        EndOfEnemyTurn();
        DropReward();
        SetEnemyState(EnemyState.Dead);

        DestroyEnemy();
    }

    private void DropReward()
    {
        //TODO : Item Drop
        //TODO : Drop EXP
    }

    private void DestroyEnemy()
    {
        TuenManager.I.MonsterTurn -= UpdateEnemyTurn;
        Destroy(gameObject);
    }
}
