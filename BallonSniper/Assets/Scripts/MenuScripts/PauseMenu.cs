using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenuUI = null;

	public void Resume()
	{
		_pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
	}

	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("StartMenu");
	}

	public void Pause()
	{
		_pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
	}
}
