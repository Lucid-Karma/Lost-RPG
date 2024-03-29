using UnityEngine;

public class PWalkState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        //Debug.Log("player entered WALK state");
        fsm.OnPlayerWalk.Invoke();
    }

    public override void UpdateState(PlayerController fsm)
    {
        if(fsm.executingPlayerState == ExecutingPlayerState.WALK)
        {
            fsm.DoneWithPath();
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if (fsm.executingPlayerState == ExecutingPlayerState.IDLE)
            fsm.SwitchState(fsm.idleState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.DIALOGUE)
            fsm.SwitchState(fsm.dialogueState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.SHOP)
            fsm.SwitchState(fsm.shoppingState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.QUEST)
            fsm.SwitchState(fsm.questState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.ATTACK)
            fsm.SwitchState(fsm.attackState);
    }
}
