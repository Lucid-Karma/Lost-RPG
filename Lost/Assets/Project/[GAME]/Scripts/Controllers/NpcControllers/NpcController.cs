using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum ExecutingNpcState
{
    NAVIGATE,
    DIALOGUE
}
public class NpcController : FSMBase<NpcController>
{
    #region FSM
    public ExecutingNpcState executingNpcState;

    public NavigateState navigateState = new NavigateState();
    public DialogueState dialogueState = new DialogueState();
    #endregion

    #region Events
    [HideInInspector]
    public UnityEvent OnNpcIdle = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnNpcWalk = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnNpcDialogue = new UnityEvent();
    #endregion

    #region Components
    private NavMeshAgent agent;
    public NavMeshAgent Agent{ get { return (agent == null) ? agent = GetComponent<NavMeshAgent>() : agent; } }
    #endregion

    #region Parameters
    Vector3 randomPoint;
    NavMeshHit hit;

    private float distance;
    Vector3 direction;
    Quaternion lookRotation;
    #endregion

    private void OnEnable()
    {
        EventManager.OnDialogueEnd.AddListener(() => executingNpcState = ExecutingNpcState.NAVIGATE);
    }
    private void OnDisable()
    {
        EventManager.OnDialogueEnd.RemoveListener(() => executingNpcState = ExecutingNpcState.NAVIGATE);
    }

    void Start()
    {
        executingNpcState = ExecutingNpcState.NAVIGATE;

        StartState(navigateState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Navigate()
    {
        if(Agent.remainingDistance <= Agent.stoppingDistance)
        {   
            Agent.SetDestination(GetRandomPos(Vector3.zero, 25.0f));
        }
    }

    public void StopNpc()
    {
        Agent.SetDestination(transform.position);
        Agent.ResetPath();
    }

    private Vector3 GetRandomPos(Vector3 center, float range)
    {
        randomPoint = center + Random.insideUnitSphere * range;
        NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas);

        return hit.position;
    }
}
