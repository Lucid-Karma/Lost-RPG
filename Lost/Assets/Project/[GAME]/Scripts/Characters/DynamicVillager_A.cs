

public class DynamicVillager_A : InteractableBase
{
    public string npcName;
    NpcController npcController;

    void Start()
    {
        npcController = GetComponent<NpcController>();
    }

    public override void Interact()
    {
        base.Interact();
        interactableRole = "Villager";
        interactableName = "Biden";
        npcController.executingNpcState = ExecutingNpcState.DIALOGUE;
    }
}
