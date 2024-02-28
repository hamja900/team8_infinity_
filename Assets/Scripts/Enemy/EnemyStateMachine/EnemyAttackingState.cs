public class EnemyAttackingState : EnemyBaseState
{
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.EnemyController.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.EnemyController.AnimationData.EnemyAttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.EnemyController.AnimationData.AttackParameterHash);
        StopAnimation(stateMachine.EnemyController.AnimationData.EnemyAttackParameterHash);
    }
}
