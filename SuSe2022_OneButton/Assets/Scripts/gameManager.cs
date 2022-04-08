using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
	public bool groundGem = false;
	public bool fireGem = false;
	public bool waterGem = false;
	public bool windGem = false;
	public bool coin = false;
	public bool dynamite = false;

	public int sceneID = 0;

	#region Singleton
	public static gameManager Instance { get; private set; }

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

	void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.buildIndex == 0)
		{
			switch (sceneID)
			{
				case 1:
					moveTowards.Instance.transform.position = new Vector3(17.5f, 0, -3.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 180f, 0);
					break;

				case 2:
					moveTowards.Instance.transform.position = new Vector3(20.5f, 0, 11.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 0, 0);
					break;

				case 3:
					moveTowards.Instance.transform.position = new Vector3(2.5f, 0, 6.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 270f, 0);
					break;
			}
		}
		else if (scene.buildIndex == 1)
		{
			switch (sceneID)
			{
				case 0:
					moveTowards.Instance.transform.position = new Vector3(0.5f, 0, -3.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 180f, 0);
					break;

				case 4:
					moveTowards.Instance.transform.position = new Vector3(14.5f, 0, 31.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 0, 0);
					break;				
			}

			if (groundGem)
			{
				Destroy(GameObject.Find("groundGem"));
			}
			if (waterGem)
			{
				Transform[] tr = GameObject.Find("Lilipads").GetComponentsInChildren<Transform>(true);
				foreach (Transform t in tr)
				{					
					t.gameObject.SetActive(true);
				}

				GameObject.Find("fakeWall").SetActive(false);
			}

		}
		else if (scene.buildIndex == 2)
		{
			switch (sceneID)
			{
				case 0:
					moveTowards.Instance.transform.position = new Vector3(7.5f, 0, 0.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 180f, 0);
					break;

				case 5:
					moveTowards.Instance.transform.position = new Vector3(17.5f, 0, 4.5f);
					moveTowards.Instance.transform.eulerAngles = new Vector3(0, 90f, 0);
					break;
			}							
		}

		moveTowards.Instance.count = 0;
		sceneID = scene.buildIndex;
	}

	public void Collect(string id)
	{
		Debug.Log("what is going on");
		switch (id)
		{
			case "groundGem":
				groundGem = true;
				break;

			case "fireGem":
				fireGem = true;
				break;

			case "waterGem":
				waterGem = true;
				break;

			case "windGem":
				windGem = true;
				break;

			case "Dynamite":
				dynamite = true;
				break;

			case "Coin":
				coin = true;
				break;
		}
	}

}
