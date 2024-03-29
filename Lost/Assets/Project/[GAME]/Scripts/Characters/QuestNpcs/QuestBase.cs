using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : InteractableBase
{
    [HideInInspector] public static bool isQuesting;

    private QuestDialogue questDialogue;
    [HideInInspector]
    public QuestDialogue QuestDialogue { get { return (questDialogue == null) ? questDialogue = GetComponent<QuestDialogue>() : questDialogue; } }
    
    public override void Interact()
    {
        isQuesting = true;
        base.Interact();
        EventManager.OnQuest.Invoke();
        QuestDialogue.PreStartDialogue();
    }
}
