using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.EnemyController.AnimationData.WanderParameterHash);
        StartAnimation(stateMachine.EnemyController.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.EnemyController.AnimationData.WanderParameterHash);
        StopAnimation(stateMachine.EnemyController.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        if (IsInAttackRange())
        {
            Debug.Log("Attack");
            stateMachine.ChangeState(stateMachine.E_AttackingState);
            return;
        }
        else if (IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.E_ChasingState);
            return;
        }
    }
}
