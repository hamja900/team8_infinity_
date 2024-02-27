using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Chasing");
        StartAnimation(stateMachine.EnemyController.AnimationData.WanderParameterHash);
        StartAnimation(stateMachine.EnemyController.AnimationData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.EnemyController.AnimationData.WanderParameterHash);
        StopAnimation(stateMachine.EnemyController.AnimationData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (!IsInChaseRange())
        {
            stateMachine.ChangeState(stateMachine.E_IdleState);
            return;
        }
        else if (IsInAttackRange())
        {
            stateMachine.ChangeState(stateMachine.E_AttackingState);
        }
    }

    private bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).sqrMagnitude;

        return playerDistanceSqr <= stateMachine.EnemyController.EnemyData.enemyAttackRange * stateMachine.EnemyController.EnemyData.enemyAttackRange;
    }
}
