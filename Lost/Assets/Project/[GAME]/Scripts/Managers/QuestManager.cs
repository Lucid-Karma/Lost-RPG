using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public GameObject[] QuestList;
    [HideInInspector] public string currentQuest;
    public Collider[] questMilestoneColliders;

    [HideInInspector]
    public enum ExecutingDialogueState
    {
        LookingForQueen,
        LookingForPrincess,
        LookingForForest,
        LookingForInformation,
        LookingForPrince,
        LookingForWizard,
    }

    public ExecutingDialogueState executingDialogueState;

    private void Start()
    {
        foreach (GameObject item in QuestList)
        {
            item.SetActive(false);
        }

        for (int i = 1; i < questMilestoneColliders.Length; i++)
        {
            questMilestoneColliders[i].enabled = false;
        }

        executingDialogueState = ExecutingDialogueState.LookingForQueen;
    }

    public void SetCurrentQuest()
    {
        switch (executingDialogueState)
        {
            case ExecutingDialogueState.LookingForQueen:
                break;
            case ExecutingDialogueState.LookingForPrincess:
                QuestList[0].SetActive(true);
                questMilestoneColliders[1].enabled = true; //Princess
                break;
            case ExecutingDialogueState.LookingForForest:
                QuestList[1].SetActive(true);
                questMilestoneColliders[0].enabled = false;    //Queen
                questMilestoneColliders[2].enabled = true; //SceneCheckPoint
                break;
            case ExecutingDialogueState.LookingForInformation:
                break;
            case ExecutingDialogueState.LookingForPrince:
                QuestList[2].SetActive(true);
                break;
            case ExecutingDialogueState.LookingForWizard:
                QuestList[3].SetActive(true);
                break;
        }
    }
}
