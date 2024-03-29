using TMPro;
using UnityEngine;

public class NameTextController : MonoBehaviour
{
    private TextMeshProUGUI nameText;
    public TextMeshProUGUI NameText
    {
        get
        {
            if (nameText == null)
                nameText = GetComponent<TextMeshProUGUI>();

            return nameText;
        }
    }

    private void OnEnable()
    {
        EventManager.OnInteract.AddListener(UpdateNameText);
    }

    private void OnDisable()
    {
        EventManager.OnInteract.RemoveListener(UpdateNameText); 
    }

    private string _name;
    private void UpdateNameText()
    {
        _name = InteractableBase.interactableName;
        NameText.text = _name;
    }
}
