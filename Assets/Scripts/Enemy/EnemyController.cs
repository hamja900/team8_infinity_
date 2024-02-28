using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Dead
}

public class EnemyController : MonoBehaviour, IDamageable
{
    [field: Header("Stats")]
    [field: SerializeField] public EnemySO EnemyData { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public AnimationData AnimationData { get; private set; }

    public Transform Target { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public EnemyMove EnemyMove { get; private set; }

    public Transform movePoint;
    public float moveSpeed = 5f;

    public bool isMonsterTurn = false;
    public bool isTurnOver = false;

    public EnemyState currentState;

    private int localTurn;

    private void Awake()
    {
        AnimationData.Initialize();

        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        EnemyMove = GetComponent<EnemyMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

        TuenManager.I.MonsterTurn += UpdateMonsterTurn;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMonsterTurn)
        {
            UpdateState();
        }
        else
            EndOfMonsterTurn();
    }

    public void SetEnemyState(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Idle:
                currentState = EnemyState.Idle;
                break;
            case EnemyState.Chasing:
                currentState = EnemyState.Chasing;
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
                break;
        }
    }

    private void CheckPlayerInRange()
    {
        if (IsInAttackRange())
        {
            if (!IsTurnOver(EnemyState.Attacking))
                SetEnemyState(EnemyState.Attacking);
            else
                return;
        }
        else if (IsInChasingRange())
        {
            if (!IsTurnOver(EnemyState.Chasing))
                SetEnemyState(EnemyState.Chasing);
            else
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

    public void TakeDamage(int damage)
    {
    }

    private void UpdateMonsterTurn(int turn)
    {
        movePoint.parent = null;
        movePoint.position = SetEnemyMovePoint();

        localTurn = turn;
        isMonsterTurn = true;

        SetEnemyState(EnemyState.Idle);
    }

    private Vector3 SetEnemyMovePoint()
    {
        Vector3 movePoint = (Target.transform.position - transform.position).normalized;

        if (Mathf.Abs(movePoint.x) < 0.5f) movePoint.x = 0f;
        else movePoint.x = movePoint.x > 0 ? 1f : -1f;

        if (Mathf.Abs(movePoint.y) < 0.5f) movePoint.y = 0f;
        else movePoint.y = movePoint.y > 0 ? 1f : -1f;

        movePoint.x += transform.position.x;
        movePoint.y += transform.position.y;

        return movePoint;
    }

    public bool IsTurnOver(EnemyState state)
    {
        switch(state)
        {
            case EnemyState.Chasing:
                if(localTurn < EnemyData.enemyMoveCost)
                {
                    return true;
                }
                return false;
            case EnemyState.Attacking:
                if(localTurn < EnemyData.enemyAttackCost)
                {
                    return true;
                }
                return false;
                default: return false;
        }
    }

    private void EndOfMonsterTurn()
    {
        movePoint.parent = gameObject.transform;

        isTurnOver = false;
    }

    public void OnTestBtn()
    {
        UpdateMonsterTurn(10);
    }
}
