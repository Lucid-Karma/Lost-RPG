
public class Queen : QuestBase
{
    public override void Interact()
    {
        //SetLines();
        interactableRole = "Queen";
        interactableName = "Sofia";
        base.Interact();
        
        QuestManager.Instance.executingDialogueState = QuestManager.ExecutingDialogueState.LookingForPrincess;
        QuestManager.Instance.SetCurrentQuest();
    }

    //private void SetLines()
    //{
    //    _lines[0] = "Welcome, brave adventurer. I have a task of great importance for you. The harmony between our lands " +
    //        "is threatened by a dire circumstance. The leader of the Dragon Village has accused our kingdom of harboring a " +
    //        "valuable possession that rightfully belongs to their people.";
    //    _lines[1] = "Your Highness, how may I assist in resolving this dispute?";
    //    _lines[2] = "You must journey to the Dragon Village and uncover the truth behind these claims. Speak to the villagers, learn of their grievances, and understand the nature of the contested item. Only then can we hope to mend the fraying bonds between our kingdoms.";
    //    _lines[3] = "Understood, Your Majesty. Is there anything else I should be aware of?";
    //    _lines[4] = "Indeed, there is more. Our beloved princess is also seeking your aid. She often finds solace by the sea's embrace, gazing upon the waves. Before departing the village, it would be wise to seek an audience with her. Her insights might guide you in your quest.";
    //    _lines[5] = "I will not fail you, Your Highness. I shall journey to the Dragon Village, uncover the truth, and seek an audience with the princess by the sea.";
    //    _lines[6] = "Your dedication is commendable. May your journey be safe and your heart be steadfast. Return with the truth, and may harmony be restored to our lands.";
    //}
}
