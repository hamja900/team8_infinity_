using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public CharacterController Controller { get; private set; }

    private EnemyStateMachine stateMachine;
    public Transform movePoint;
    public float moveSpeed = 5f;

    public bool isTurnOver = false;

    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Controller = GetComponent<CharacterController>();

        stateMachine = new EnemyStateMachine(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine.ChangeState(stateMachine.E_IdleState);
        movePoint.parent = null;

        TuenManager.I.MonsterTurn += UpdateMonsterTurn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {

    }

    private void UpdateMonsterTurn(int turn)
    {
        movePoint.parent = null;
        movePoint.position = SetEnemyMovePoint();
        StartCoroutine(MonsterMove());
    }

    IEnumerator MonsterMove()
    {
        while (!isTurnOver)
        {
            stateMachine.Update();
            yield return new WaitForEndOfFrame();
        }

        EndOfMonsterTurn();
    }

    private Vector3 SetEnemyMovePoint()
    {
        Vector3 movePoint = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).normalized;

        if (Mathf.Abs(movePoint.x) < 0.5f) movePoint.x = 0f;
        else movePoint.x = movePoint.x > 0 ? 1f : -1f;

        if (Mathf.Abs(movePoint.y) < 0.5f) movePoint.y = 0f;
        else movePoint.y = movePoint.y > 0 ? 1f : -1f;

        movePoint.x += transform.position.x;
        movePoint.y += transform.position.y;

        return movePoint;
    }

    private void EndOfMonsterTurn()
    {
        movePoint.parent = gameObject.transform;
        stateMachine.EnemyIsMoved(false);
        isTurnOver = false;
    }

    public void OnTestBtn()
    {
        UpdateMonsterTurn(10);
    }
}
