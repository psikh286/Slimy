using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Speaker[] speakers;		

	public void StartDialogue()
	{
        dialogueManager.Instance.OpenDialogue(messages, speakers);
	}
}

[System.Serializable]
public class Message
{
    public int SpeakerID;
    public string message;
}

[System.Serializable]
public class Speaker
{
    public Sprite background;
}