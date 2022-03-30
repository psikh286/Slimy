using UnityEngine;
using UnityEngine.UI;

public class diologueManager : MonoBehaviour
{
    #region Singleton
    public static diologueManager Instance { get; private set; }

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

	public Image speakerImage;
    public Text speakerName;
    public Text messageText;
    public RectTransform dialogueBox;
    public static bool isActive;

    private Message[] _currentMessages;
    private Speaker[] _currentSpeakes;
    private int _activeMessage = 0;

    public void OpenDialogue(Message[] messages, Speaker[] speakers)
	{
        _currentMessages = messages;
        _currentSpeakes = speakers;
        _activeMessage = 0;

        moveTowards.can_move = false;
        isActive = true;

        Debug.Log("Started dialogue");
	}

    private void DisplayMessage()
	{        
        Message _messageToDisplay = _currentMessages[_activeMessage];
        messageText.text = _messageToDisplay.message;

        Speaker _speakerToDisplay = _currentSpeakes[_messageToDisplay.SpeakerID];
        speakerImage.sprite = _speakerToDisplay.sprite;
        speakerName.text = _speakerToDisplay.name;
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
            isActive = false;
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
