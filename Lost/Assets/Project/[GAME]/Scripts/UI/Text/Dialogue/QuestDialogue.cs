using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestDialogue : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;
    public TextMeshProUGUI textComponent;
    public string[] _lines;
    private int index;
    [SerializeField] private Sprite _npcAvatar;
    [SerializeField] private Sprite _playerAvatar;
    [SerializeField] private Image _avatar;
    [SerializeField] private TextMeshProUGUI _role;
    [SerializeField] private TextMeshProUGUI _name;
    private string _npcRole;
    private string _npcName;
    private string _playerRole = "Hunter";
    private string _playerName = "You";

    void Start()
    {
        _dialoguePanel.SetActive(false);
    }

    public void PreStartDialogue()
    {
        _npcAvatar = QuestBase.interactableAvatar;
        _npcRole = QuestBase.interactableRole;
        _npcName = QuestBase.interactableName;
        if(_npcAvatar != null)
            _avatar.sprite = _npcAvatar;

        textComponent.text = string.Empty;

        _dialoguePanel.SetActive(true);

        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;

        textComponent.text = _lines[0];
    }

    void NextLine()
    {
        if (index < _lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            textComponent.text = _lines[index];

            if (index % 2 == 0)
            {
                _avatar.sprite = _npcAvatar;
                _role.text = _npcRole;
                _name.text = _npcName;

            }
            else
            {
                _avatar.sprite = _playerAvatar;
                _role.text = _playerRole;
                _name.text = _playerName;
            }
                
        }
        else
        {
            _dialoguePanel.SetActive(false);
            EventManager.OnDialogueEnd.Invoke();
            QuestBase.isQuesting = false;
            
            this.enabled = false;
        }
    }

    void Update()
    {
        if (!QuestBase.isQuesting) return;

        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }
}
