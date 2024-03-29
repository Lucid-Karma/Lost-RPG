using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    [SerializeField] protected Sprite Avatar;
    [HideInInspector] public static Sprite interactableAvatar { get; protected set; }
    [HideInInspector] public static string interactableRole { get; protected set; }
    [HideInInspector] public static string interactableName { get; protected set; }

    public virtual void Interact()
    {
        interactableAvatar = Avatar;
    }
}
