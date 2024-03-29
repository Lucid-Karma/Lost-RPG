using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : QuestBase
{
    public override void Interact()
    {
        interactableRole = "Princess";
        interactableName = "Maria";
        base.Interact();

        QuestManager.Instance.executingDialogueState = QuestManager.ExecutingDialogueState.LookingForForest;
        QuestManager.Instance.SetCurrentQuest();
    }
}
