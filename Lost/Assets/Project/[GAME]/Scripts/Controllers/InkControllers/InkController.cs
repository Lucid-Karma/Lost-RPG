using System.Collections;
using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class InkController : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;

    #region Title&Image
    public static Image villagerAvatar;
    #endregion

    void Awake()
    {
        villagerAvatar = transform.GetChild(1).GetComponent<Image>();
    }

    void OnEnable()
    {
        EventManager.OnVillagerMeet.AddListener(StartStory);
    }
    void OnDisable()
    {
        EventManager.OnVillagerMeet.RemoveListener(StartStory);
    }

    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        switch (QuestManager.Instance.executingDialogueState)
        {
            case QuestManager.ExecutingDialogueState.LookingForQueen:
                QueenMeet();
                break;

            case QuestManager.ExecutingDialogueState.LookingForPrincess:
                PrincessMeet();
                break;

            case QuestManager.ExecutingDialogueState.LookingForForest:
                LeaveVillageA();
                break;
        }

        /*if (!QuestManager.Instance.isQueenVisited)
        {
            story = new Story(inkJSONAsset_BeforeQueenMeet.text);
        }
        else
        {
            if (!QuestManager.Instance.isPrincessFound)
            {
                story = new Story(inkJSONAsset_BeforePrincessMeet[UnityEngine.Random.Range(0, inkJSONAsset_BeforePrincessMeet.Length)].text);
            }
            else
            {
                story = new Story(inkJSONAsset_AfterPrincessMeet.text);
            }
        }*/

        if (OnCreateStory != null) OnCreateStory(story);
        EventManager.OnVillagerInteract.Invoke();
        RefreshView();
    }

    private void LeaveVillageA()
    {
        story = new Story(inkJSONAsset_AfterPrincessMeet.text);
    }

    private void PrincessMeet()
    {
        story = new Story(inkJSONAsset_BeforePrincessMeet[UnityEngine.Random.Range(0, inkJSONAsset_BeforePrincessMeet.Length)].text);
    }

    private void QueenMeet()
    {
        story = new Story(inkJSONAsset_BeforeQueenMeet.text);
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the buttons on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            StartCoroutine(EndChat());
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a textbox showing the the line of text
    void CreateContentView(string text)
    {
        _text.text = text;
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(_buttonArea.transform, false);

        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text>();
        choiceText.text = text;

        return choice;
    }

    // Destroys all the children of this gameobject (_buttonArea)
    void RemoveChildren()
    {
        int childCount = _buttonArea.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(_buttonArea.transform.GetChild(i).gameObject);
        }
    }

    IEnumerator EndChat()
    {
        yield return new WaitForSeconds(1.0f);

        EventManager.OnDialogueEnd.Invoke();
    }


    [SerializeField]
    private TextAsset inkJSONAsset_BeforeQueenMeet = null;
    [SerializeField]
    private TextAsset[] inkJSONAsset_BeforePrincessMeet = null;
    [SerializeField]
    private TextAsset inkJSONAsset_AfterPrincessMeet = null;
    public Story story;

    [SerializeField]
    private GameObject _buttonArea = null;
    [SerializeField]
    private TextMeshProUGUI _text = null;

    // UI Prefabs
    [SerializeField]
    private Button buttonPrefab = null;
}