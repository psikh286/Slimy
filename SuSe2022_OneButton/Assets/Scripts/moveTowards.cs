using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class moveTowards : MonoBehaviour
{
	[SerializeField]
	private RectTransform button;
	[SerializeField]
	private Image fillImage;
	
		
	public static bool can_move = true;
	public float holdTime;
	public int count = 0;

	private float currentTime = 0;
	private Vector3[] directions = new Vector3[] {Vector3.forward, Vector3.right, Vector3.back, Vector3.left};
	private Vector3[] rotation = new Vector3[] {new Vector3(0, 75f, 0), new Vector3(75f, 0, 0), new Vector3(0, -75f, 0), new Vector3(-75f, 0, 0)};	

	#region Singleton
	public static moveTowards Instance { get; private set; }

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

	private void Update()
	{
		if (dialogueManager.isActive)
			return;

		if (can_move)
		{			
			if (Input.GetKey("space"))
			{				
				currentTime += Time.deltaTime;
				if (currentTime > holdTime)
				{
					StartCoroutine(Move(0.4f));
					Reset();
				} 		
				fillImage.fillAmount = currentTime / holdTime;
			}

			if (Input.GetKeyUp("space"))
			{
				if (currentTime <= holdTime)
				{
					ChangeUI();
				}
				Reset();
			}

		}
	}

	private void Reset()
	{
		currentTime = 0;
		fillImage.fillAmount = currentTime / holdTime;
	}

	private void ChangeUI()
	{
		can_move = false;
		count++;
		if (count == rotation.Length)
			count = 0;

		button.localPosition = rotation[count];
		can_move = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Nature")
		{
			other.transform.GetComponentInChildren<MeshRenderer>().enabled = false;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Nature")
		{
			other.transform.GetComponentInChildren<MeshRenderer>().enabled = true;
		}
	}

	private IEnumerator Move(float delay)
	{
		can_move = false;
		RaycastHit hit;
		if (!Physics.Raycast(transform.position, directions[count], out hit, 1f))
		{			
			transform.position += directions[count];			
			yield return new WaitForSeconds(delay);
			can_move = true;
		}
		else
		{
			switch (hit.transform.tag)
			{
				case "Dialogue":
					hit.transform.GetComponent<dialogueTrigger>().StartDialogue();
					break;

				case "Wall":
					can_move = true;
					break;

				case "Raft":
					can_move = true;
					hit.transform.GetComponent<travelTo>().ChangeScene();
					break;

				case "Nature":
					transform.position += directions[count];
					yield return new WaitForSeconds(delay);
					can_move = true;
					break;

				case "Collectable":
					transform.position += directions[count];
					yield return new WaitForSeconds(delay);
					can_move = true;
					gameManager.Instance.Collect(hit.transform.name);
					Destroy(hit.transform.gameObject); 
					break;
			}
		}
		yield break;
	}
}
