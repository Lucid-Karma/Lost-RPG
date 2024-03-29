using UnityEngine;
using UnityEngine.UI;

public class AvatarImageController : MonoBehaviour
{
    private Image avatarImage;
    public Image AvatarImage { get { return (avatarImage == null) ? avatarImage = GetComponent<Image>() : avatarImage; } }

    private void OnEnable()
    {
        EventManager.OnInteract.AddListener(UpdateAvatarImage);
    }
    private void OnDisable()
    {
        EventManager.OnInteract.RemoveListener(UpdateAvatarImage);
    }

    private void UpdateAvatarImage()
    {
        AvatarImage.sprite = InteractableBase.interactableAvatar;
    }
}