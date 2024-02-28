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
        //Vector3 moveDirection = GetMovementDirection();
        
        Move(stateMachine.EnemyController.movePoint.position);
    }

    //private Vector3 GetMovementDirection()
    //{
    //    Vector3 movePoint = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).normalized;

    //    if (Mathf.Abs(movePoint.x) < 0.5f) movePoint.x = 0f;
    //    else movePoint.x = movePoint.x > 0 ? 1f : -1f;

    //    if (Mathf.Abs(movePoint.y) < 0.5f) movePoint.y = 0f;
    //    else movePoint.y = movePoint.y > 0 ? 1f : -1f;

    //    movePoint.x += stateMachine.EnemyController.transform.position.x;
    //    movePoint.y += stateMachine.EnemyController.transform.position.y;

    //    return movePoint;
    //}

    private void Move(Vector3 moveDirection)
    {
        EnemyController enemyController = stateMachine.EnemyController;

        enemyController.movePoint.position = moveDirection;
        enemyController.transform.position = Vector3.MoveTowards(enemyController.transform.position, enemyController.movePoint.position, enemyController.moveSpeed * Time.deltaTime);

        if (enemyController.transform.position.Equals(enemyController.movePoint.position) && !stateMachine.IsMoved)
        {
            stateMachine.EnemyIsMoved(true);
            Debug.Log("true");
        }
    }

    protected bool IsInChaseRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.EnemyController.EnemyData.enemyDetectRange * stateMachine.EnemyController.EnemyData.enemyDetectRange;
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Target.transform.position - stateMachine.EnemyController.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.EnemyController.EnemyData.enemyAttackRange * stateMachine.EnemyController.EnemyData.enemyAttackRange;
    }
}
