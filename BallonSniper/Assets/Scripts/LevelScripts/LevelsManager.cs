using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
	public delegate void ChangeLevelParametrsCallBack(float newParametr);
	public static event ChangeLevelParametrsCallBack ChangeBalloonsVelocity;
	public static event ChangeLevelParametrsCallBack ChangeSpawnInterval;

	[SerializeField] private Text _scoreText = null;
	private int _score = 0;

	private void OnEnable()
	{
		ShootingScript.AddScore += ChangeScore;
	}

	private void ChangeScore()
	{
		_score += 100;
		_scoreText.text = "Score: " + _score.ToString();
		CheckScoreForChangeLevel();
	}

	private void CheckScoreForChangeLevel()
	{
		if (_score == 1000)
		{
			ChangeBalloonsVelocity?.Invoke(2f);
			ChangeSpawnInterval?.Invoke(30f);
		}
		else if (_score == 3000)
		{
			ChangeBalloonsVelocity?.Invoke(3f);
			ChangeSpawnInterval?.Invoke(40f);
		}
	}
}
