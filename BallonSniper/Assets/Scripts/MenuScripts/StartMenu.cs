using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	[SerializeField] private Text _maxScoreText = null;

	private void Start()
	{
		_maxScoreText.text = PlayerPrefs.GetInt("maxScore").ToString();
	}

	public void StartButton()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void ExitButton()
	{
		Application.Quit();
	}
}
