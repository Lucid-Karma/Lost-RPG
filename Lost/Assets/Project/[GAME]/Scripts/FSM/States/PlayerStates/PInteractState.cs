using UnityEngine;

public class PInteractState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("player entered INTERACT state");
    }

    public override void UpdateState(PlayerController fsm)
    {
        if(fsm.executingPlayerState == ExecutingPlayerState.INTERACT)
        {
            fsm.DoneWithPath();
            //fsm.MeetNpc();
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if(fsm.executingPlayerState == ExecutingPlayerState.IDLE)
            fsm.SwitchState(fsm.idleState);
        else if(fsm.executingPlayerState == ExecutingPlayerState.WALK)
            fsm.SwitchState(fsm.walkState);
    }
}
