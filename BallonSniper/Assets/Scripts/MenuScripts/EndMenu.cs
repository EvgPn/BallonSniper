using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
	[SerializeField] private Text _achievedScoreText = null;

	private int _currentScore;
	private int _maxScore;

	private void Start()
	{
		_currentScore = PlayerPrefs.GetInt("currentScore");
		_maxScore = PlayerPrefs.GetInt("maxScore");

		if (_currentScore > _maxScore)
		{
			PlayerPrefs.SetInt("maxScore", _currentScore);
		}

		_achievedScoreText.text = "Your score is: " + _currentScore.ToString();
	}

	public void NewGameButton()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void MainMenuButton()
	{
		SceneManager.LoadScene("StartMenu");
	}
}
