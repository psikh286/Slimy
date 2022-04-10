using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
	public static pauseMenu Instance { get; private set; }

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


	public GameObject pause_menu;
	public GameObject game_over;
	private bool game_is_paused;	

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (game_is_paused)
			{
				Resume();
			}else
			{
				Pause();
			}
		}		

	}

	public void Pause()
	{
		pause_menu.SetActive(true);
		moveTowards.can_move = false;
		game_is_paused = true;
	}

	public void Resume()
	{
		pause_menu.SetActive(false);
		moveTowards.can_move = true;
		game_is_paused = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
