using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BalloonsCounter : MonoBehaviour
{
	[SerializeField] private Text _score = null;

	public int BalloonsInScene = 0;
	private int _maxAmountOfBalloons = 35;

	private void Update()
	{
		if (BalloonsInScene >= _maxAmountOfBalloons)
		{
			int currentScore = int.Parse(_score.text.Split(' ')[1]);
			PlayerPrefs.SetInt("currentScore", currentScore);

			SceneManager.LoadScene("EndMenu");
		}
	}
}
