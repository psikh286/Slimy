using UnityEngine;
using UnityEngine.SceneManagement;

public class travelTo : MonoBehaviour
{
	public int index;
	public void ChangeScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
	}
}
