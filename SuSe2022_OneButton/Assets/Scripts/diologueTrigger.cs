using UnityEngine;

public class diologueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Speaker[] speakers;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			StartDiologue();			
		}
	}

	public void StartDiologue()
	{        
        diologueManager.Instance.OpenDialogue(messages, speakers);
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
    public string name;
    public Sprite sprite;
}