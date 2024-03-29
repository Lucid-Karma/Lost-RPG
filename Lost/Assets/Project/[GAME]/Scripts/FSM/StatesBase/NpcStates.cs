using UnityEngine;

public abstract class NpcStates : IStates<NpcController>
{
    public abstract void EnterState(NpcController fsm);
    public abstract void UpdateState(NpcController fsm);
    public abstract void ExitState(NpcController fsm);
}
