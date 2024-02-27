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
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void TakeDamage(int damage)
    {

    }
}
