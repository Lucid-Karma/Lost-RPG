using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    NpcController npcController;
    NpcController NpcController { get { return (npcController == null) ? npcController = GetComponentInParent<NpcController>() : npcController; } }

    void OnEnable()
    {
        NpcController.OnNpcIdle.AddListener(() => InvokeTrigger("Idle"));
        NpcController.OnNpcWalk.AddListener(() => InvokeTrigger("Walk"));
    }
    void OnDisable() 
    {
        NpcController.OnNpcIdle.RemoveListener(() => InvokeTrigger("Idle"));
        NpcController.OnNpcWalk.RemoveListener(() => InvokeTrigger("Walk"));
    }

    private void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
}