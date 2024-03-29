using UnityEngine;

public class DialogueState : NpcStates
{
    public override void EnterState(NpcController fsm)
    {
        //Debug.Log("npc entered dialogue state");
        fsm.StopNpc();
        fsm.OnNpcIdle.Invoke();
        EventManager.OnVillagerMeet.Invoke();
    }

    public override void UpdateState(NpcController fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.DIALOGUE)
        {

        }
        else
            ExitState(fsm);
    }

    public override void ExitState(NpcController fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.NAVIGATE)
            fsm.SwitchState(fsm.navigateState);
    }
}
