using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void HandleInput()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Update()
    {
        Move();
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.EnemyController.Animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.EnemyController.Animator.SetBool(animationHash, false);
    }

    private void Move()
    {
        Vector3 moveDirection = GetMovementDirection();
        
        Move(moveDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 movePoint = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).normalized;

        if (Mathf.Abs(movePoint.x) < 0.5f) movePoint.x = 0f;
        else movePoint.x = movePoint.x > 0 ? 1f : -1f;

        if (Mathf.Abs(movePoint.y) < 0.5f) movePoint.y = 0f;
        else movePoint.y = movePoint.y > 0 ? 1f : -1f;

        return movePoint;
    }

    private void Move(Vector3 moveDirection)
    {
        EnemyController enemyController = stateMachine.EnemyController;

        enemyController.movePoint.position = moveDirection;
        enemyController.transform.position = Vector3.MoveTowards(enemyController.transform.position, enemyController.movePoint.position, enemyController.moveSpeed * Time.deltaTime);
    }

    protected bool IsInChaseRange()
    {
        //float distance = Vector3.Distance(stateMachine.Target.transform.position, stateMachine.EnemyController.transform.position);
        //return distance <= stateMachine.EnemyController.EnemyData.enemyDetectRange;

        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.EnemyController.EnemyData.enemyDetectRange * stateMachine.EnemyController.EnemyData.enemyDetectRange;
    }
}
