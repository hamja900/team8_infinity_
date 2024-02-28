using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public EnemyController EnemyController { get; }

    public Transform Target { get; private set; }

    public EnemyIdleState E_IdleState { get; private set; }
    public EnemyChasingState E_ChasingState { get; private set; }
    public EnemyAttackingState E_AttackingState { get; private set; }

    public int EnemyMovementSpeed { get; private set; }

    public bool IsMoved { get; private set; }

    public EnemyStateMachine(EnemyController enemyController)
    {
        EnemyController = enemyController;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        E_IdleState = new EnemyIdleState(this);
        E_ChasingState = new EnemyChasingState(this);
        E_AttackingState = new EnemyAttackingState(this);

        IsMoved = false;
    }

    public void EnemyIsMoved(bool isMoved)
    {
        IsMoved = isMoved;
    }
}
