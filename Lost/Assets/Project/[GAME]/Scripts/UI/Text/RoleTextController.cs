using TMPro;
using UnityEngine;

public class RoleTextController : MonoBehaviour
{
    private TextMeshProUGUI roleText;
    public TextMeshProUGUI RoleText
    {
        get
        {
            if (roleText == null)
                roleText = GetComponent<TextMeshProUGUI>();

            return roleText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnInteract.AddListener(UpdateRoleText);
    }

    private void OnDisable()
    {
        EventManager.OnInteract.RemoveListener(UpdateRoleText); 
    }

    public string role;
    private void UpdateRoleText()
    {
        role = InteractableBase.interactableRole;
        RoleText.text = role;
    }
}
