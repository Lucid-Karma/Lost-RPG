using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public enum ExecutingPlayerState
{
    IDLE,
    WALK,
    SHOP,
    INTERACT,
    DIALOGUE,
    QUEST,
    ATTACK
}
public class PlayerController : FSMBase<PlayerController>
{
    #region FSM
    public ExecutingPlayerState executingPlayerState;

    public PIdleState idleState = new();
    public PWalkState walkState = new();
    public PInteractState interactState = new();
    public PShoppingState shoppingState = new();
    public PDialogueState dialogueState = new();
    public PQuestState questState = new();
    public PAttackState attackState = new();
    #endregion   

    #region Events
    [HideInInspector]
    public UnityEvent OnPlayerIdle = new();
    [HideInInspector]
    public UnityEvent OnPlayerWalk = new();
    [HideInInspector]
    public UnityEvent OnPlayerAttack = new();
    #endregion

    #region Components
    private NavMeshAgent agent;
    public NavMeshAgent Agent{ get { return (agent == null) ? agent = GetComponent<NavMeshAgent>() : agent; } }
    #endregion

    #region Referance Scripts
    PlayerAnimationController playerAnimationController;
    PlayerAnimationController PlayerAnimationController { get { return (playerAnimationController == null) ? playerAnimationController = GetComponentInChildren<PlayerAnimationController>() : playerAnimationController; } }
    
    InteractableBase interactable;
    #endregion

    #region Parameters
    Camera _playerCam;
    private PlayerInput playerInput;
    [HideInInspector] public InputAction mouseClick;
    #endregion

    private void Awake()
    {
        _playerCam = Camera.main;
        playerInput = GetComponent<PlayerInput>();
        mouseClick = playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;

        EventManager.OnDialogueEnd.AddListener(() => mouseClick.Enable());
        EventManager.OnShoppingEnd.AddListener(() => mouseClick.Enable());
    }
    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();

        EventManager.OnDialogueEnd.RemoveListener(() => mouseClick.Enable());
        EventManager.OnShoppingEnd.RemoveListener(() => mouseClick.Enable());
    }

    void Start()
    {
        EventManager.OnLevelStart.Invoke();
        executingPlayerState = ExecutingPlayerState.IDLE;

        StartState(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    //LayerMask mask;
    private void MousePressed(InputAction.CallbackContext context)
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        //mask = LayerMask.GetMask("Ground");

        Ray ray = _playerCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100/*, mask*/) && raycastResults.Count <= 0)
        {
            //Debug.Log(hit.collider.gameObject.layer);
            interactable = hit.collider.GetComponent<InteractableBase>();

            MovePlayerTo(hit.point);
            if(executingPlayerState != ExecutingPlayerState.WALK)
            {
                executingPlayerState = ExecutingPlayerState.WALK;
            }
        }
        //else
        //{
        //    Debug.Log(mask);
        //}
    }

    public void HandleInteract()
    {
        if (interactable != null)
        {
            Agent.stoppingDistance = 1.5f;
            interactable?.Interact();

            if (interactable is DynamicVillager_A)
                executingPlayerState = ExecutingPlayerState.DIALOGUE;
            else if (interactable is VendorBase)
                executingPlayerState = ExecutingPlayerState.SHOP;
            else
                executingPlayerState = ExecutingPlayerState.QUEST;
        }
    }

    private void MovePlayerTo(Vector3 targetPosition)
    {
        Agent.SetDestination(targetPosition);
    }

    public void StopPlayer()
    {
        Agent.SetDestination(transform.position);
    }

    public void DoneWithPath()
    {
        if(Agent.remainingDistance <= Agent.stoppingDistance)
        {
            executingPlayerState = ExecutingPlayerState.IDLE;
        }
    }
}
