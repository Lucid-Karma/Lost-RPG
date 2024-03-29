using UnityEngine;

public class PIdleState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        //Debug.Log("player entered IDLE state");
        fsm.StopPlayer();
        fsm.OnPlayerIdle.Invoke();
        fsm.HandleInteract();
    }

    public override void UpdateState(PlayerController fsm)
    {
        if(fsm.executingPlayerState == ExecutingPlayerState.IDLE)
        {   

        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if (fsm.executingPlayerState == ExecutingPlayerState.WALK)
            fsm.SwitchState(fsm.walkState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.ATTACK)
            fsm.SwitchState(fsm.attackState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.INTERACT)
            fsm.SwitchState(fsm.interactState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.DIALOGUE)
            fsm.SwitchState(fsm.dialogueState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.QUEST)
            fsm.SwitchState(fsm.questState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.SHOP)
            fsm.SwitchState(fsm.shoppingState);
    }
}