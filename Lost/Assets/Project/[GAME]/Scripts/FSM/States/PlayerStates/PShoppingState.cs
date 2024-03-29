using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShoppingState : PlayerStates
{
    public override void EnterState(PlayerController fsm)
    {
        EventManager.OnInteract.Invoke();
        fsm.mouseClick.Disable();
    }

    public override void UpdateState(PlayerController fsm)
    {
        if (fsm.executingPlayerState == ExecutingPlayerState.SHOP)
        {

        }
        else
            ExitState(fsm);
    }

    public override void ExitState(PlayerController fsm)
    {
        if (fsm.executingPlayerState == ExecutingPlayerState.IDLE)
            fsm.SwitchState(fsm.idleState);
        else if (fsm.executingPlayerState == ExecutingPlayerState.WALK)
            fsm.SwitchState(fsm.walkState);
    }
}
