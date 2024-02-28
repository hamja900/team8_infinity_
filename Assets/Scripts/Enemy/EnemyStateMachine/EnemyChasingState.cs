public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
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

        if (!stateMachine.IsMoved)
        {
            if (!IsInChaseRange())
            {
                stateMachine.ChangeState(stateMachine.E_IdleState);
                return;
            }
        }
        else
        {
            stateMachine.ChangeState(stateMachine.E_IdleState);
            stateMachine.EnemyController.isTurnOver = true;
            return;
        }
    }
}
