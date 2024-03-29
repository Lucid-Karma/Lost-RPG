using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    PlayerController playerController;
    PlayerController PlayerController { get { return (playerController == null) ? playerController = GetComponentInParent<PlayerController>() : playerController; } }

    void OnEnable()
    {
        PlayerController.OnPlayerIdle.AddListener(() => InvokeTrigger("Idle"));
        PlayerController.OnPlayerWalk.AddListener(() => InvokeTrigger("Walk"));
    }
    void OnDisable() 
    {
        PlayerController.OnPlayerIdle.RemoveListener(() => InvokeTrigger("Idle"));
        PlayerController.OnPlayerWalk.RemoveListener(() => InvokeTrigger("Walk"));

    }

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
}