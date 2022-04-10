using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    #region Singleton
    public static dialogueManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
            Instance = this;
            DontDestroyOnLoad(gameObject);
		}
        else
		{
            Destroy(gameObject);
		}
	}

    #endregion

    public GameObject[] UIElements;
    public Image speakerBackground;
    public TextMeshProUGUI messageText;
    public RectTransform dialogueBox;
    public static bool isActive;

    private Message[] _currentMessages;
    private Speaker[] _currentSpeakes;
    private int _activeMessage = 0;

    public void OpenDialogue(Message[] messages, Speaker[] speakers)
	{
        foreach (GameObject UIElement in UIElements)
        {
            UIElement.SetActive(false);
        }

        _currentMessages = messages;
        _currentSpeakes = speakers;
        _activeMessage = 0;

        moveTowards.can_move = false;
        isActive = true;

        Debug.Log("Started dialogue");
        dialogueBox.transform.localScale = Vector3.one;
        DisplayMessage();
	}

    private void DisplayMessage()
	{        
        Message _messageToDisplay = _currentMessages[_activeMessage];
        messageText.text = _messageToDisplay.message;

        Speaker _speakerToDisplay = _currentSpeakes[_messageToDisplay.SpeakerID];
        speakerBackground.sprite = _speakerToDisplay.background;
	}

    private void NextMessage()
	{
        _activeMessage++;
        if (_activeMessage < _currentMessages.Length)
		{
            DisplayMessage();
		}
        else
		{
            foreach (GameObject UIElement in UIElements)
            {
                UIElement.SetActive(true);
            }

            dialogueBox.transform.localScale = Vector3.zero;
            isActive = false;
            moveTowards.can_move = true;
            gameManager.Instance.Talked();
            Debug.Log("Finished dialogue");
		}
	}

	private void Update()
	{
        if (isActive && Input.GetKeyDown("space"))
		{
            NextMessage();
		}
	}
}
