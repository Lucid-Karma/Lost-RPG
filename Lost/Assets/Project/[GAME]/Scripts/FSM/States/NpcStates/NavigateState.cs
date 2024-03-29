using UnityEngine;

public class NavigateState : NpcStates
{
    public override void EnterState(NpcController fsm)
    {
        //Debug.Log("npc entered navigate state");
        fsm.OnNpcWalk.Invoke();
    }

    public override void UpdateState(NpcController fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.NAVIGATE)
        {
            fsm.Navigate();
        }
        else
            ExitState(fsm);
    }

    public override void ExitState(NpcController fsm)
    {
        if(fsm.executingNpcState == ExecutingNpcState.DIALOGUE)
            fsm.SwitchState(fsm.dialogueState);
    }
}
