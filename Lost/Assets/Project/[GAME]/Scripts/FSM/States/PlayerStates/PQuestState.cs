using UnityEngine;

public class PQuestState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        Debug.Log("player entered quest state");
        EventManager.OnInteract.Invoke();
        fsm.mouseClick.Disable();
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingPlayerState == ExecutingPlayerState.QUEST)
        {
            //fsm.MeetNpc();
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        //fsm.Agent.stoppingDistance = 0.05f;

        if (fsm.executingPlayerState == ExecutingPlayerState.IDLE)
            fsm.SwitchState(fsm.idleState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.WALK)
            fsm.SwitchState(fsm.walkState);
    }
}