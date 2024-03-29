using UnityEngine;

public abstract class PlayerStates : IStates<PlayerController>
{
    public abstract void EnterState(PlayerController fsm);
    public abstract void UpdateState(PlayerController fsm);
    public abstract void ExitState(PlayerController fsm);
}
