using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

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

    public EnemyMove EnemyMove { get; private set; }
    public EnemyAttack EnemyAttack { get; private set; }
    public EnemyAnimation EnemyAnimation { get; private set; }

    public Transform Target { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }

    public Transform movePoint;
    public float moveSpeed = 5f;

    public bool isEnemyTurn = false;
    public bool isTurnOver = false;

    public EnemyState currentState;

    public int localTurn;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody = GetComponent<Rigidbody>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

        EnemyMove = GetComponent<EnemyMove>();
        EnemyAttack = GetComponent<EnemyAttack>();
        EnemyAnimation = GetComponent<EnemyAnimation>();

        EnemyData.enemyHealth = EnemyData.enemyMaxHealth;
    }

    void Start()
    {
        movePoint.parent = null;

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
                currentState = EnemyState.Chasing;
                EnemyAnimation.ToggleAnimation("Walk", true);
                break;
            case EnemyState.Attacking: 
                currentState = EnemyState.Attacking;
                //EnemyAnimation.ToggleAnimation("EnemyAttack", true);
                //EnemyAnimation.TriggerAnimation("EnemyAttack");
                EnemyAnimation.PlayAttackAnimation();
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
                currentState = EnemyState.Chasing;
                EnemyAnimation.ToggleAnimation("Walk", false);
                break;
            case EnemyState.Attacking:
                currentState = EnemyState.Attacking;
                //EnemyAnimation.ToggleAnimation("EnemyAttack", false);
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
        }
    }

    private void CheckPlayerInRange()
    {
        if (IsInAttackRange())
        {
            if (!IsTurnOver(EnemyState.Attacking))
            {
                SetEnemyState(EnemyState.Attacking);
                Debug.Log("Check Attack");
            }
            else
                return;
        }
        else if (IsInChasingRange())
        {
            if (movePoint.position.x < 0) SpriteRenderer.flipX = true;
            else SpriteRenderer.flipX = false;

            Debug.Log("IsInChasingRange");

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

    private void UpdateEnemyTurn(int turn)
    {
        movePoint.parent = null;
        movePoint.position = SetEnemyMovePoint();

        localTurn = turn;
        isEnemyTurn = true;

        SetEnemyState(EnemyState.Idle);
        //Invoke("StartEnemyTurn", 1);
    }

    private void StartEnemyTurn()
    {
        
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
                    EndOfEnemyTurn();
                    return true;
                }
                localTurn -= EnemyData.enemyMoveCost;
                movePoint.position = SetEnemyMovePoint();
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

    private void EndOfEnemyTurn()
    {
        movePoint.parent = gameObject.transform;
        
        TuenManager.I.EnemyTurnOver();
        isEnemyTurn = false;
    }

    public void OnTestBtn()
    {
        UpdateEnemyTurn(10);
    }

    public void TakeDamage(int damage)
    {
        EnemyData.enemyHealth -= damage;
        if(EnemyData.enemyHealth <= 0)
        {
            EnemyData.enemyHealth = 0;
            Die();
        }
    }

    public Vector2 Pos()
    {
        return (Vector2)transform.position;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
