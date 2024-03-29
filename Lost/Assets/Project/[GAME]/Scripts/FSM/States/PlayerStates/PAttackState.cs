using UnityEngine;

public class PAttackState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("player entered ATTACK state");
    }

    public override void UpdateState(PlayerController fsm)
    {
        if(fsm.executingPlayerState == ExecutingPlayerState.ATTACK)
        {   

        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if(fsm.executingPlayerState == ExecutingPlayerState.WALK)
            fsm.SwitchState(fsm.walkState);
        else if(fsm.executingPlayerState == ExecutingPlayerState.IDLE)
            fsm.SwitchState(fsm.idleState);
    }
}
