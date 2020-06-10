using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
	public delegate void ChangeLevelParametrsCallBack(float newParametr);
	public static event ChangeLevelParametrsCallBack ChangeBalloonsVelocity;
	public static event ChangeLevelParametrsCallBack ChangeSpawnInterval;

	public static float _defaultBallonVelocity = 3f;
	public static float _valueForVelocityOfOldBallonos;

	[SerializeField] private Text _nextLevelText = null;
	[SerializeField] private Text _scoreText = null;
	private int _score = 0;
	
	private void OnEnable()
	{
		ShootingScript.AddScore += ChangeScore;
	}

	private void Start()
	{
		_nextLevelText.enabled = false;
		_valueForVelocityOfOldBallonos = _defaultBallonVelocity;
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
			_defaultBallonVelocity = _valueForVelocityOfOldBallonos * 2f;
			StartCoroutine(ShowNextLevelText());
			ChangeBalloonsVelocity?.Invoke(_valueForVelocityOfOldBallonos * 2f);
			ChangeSpawnInterval?.Invoke(30f);
		}
		else if (_score == 3000)
		{
			_defaultBallonVelocity = _valueForVelocityOfOldBallonos * 3f;
			StartCoroutine(ShowNextLevelText());
			ChangeBalloonsVelocity?.Invoke(_valueForVelocityOfOldBallonos * 3f);
			ChangeSpawnInterval?.Invoke(40f);
		}
	}

	private IEnumerator ShowNextLevelText()
	{
		_nextLevelText.enabled = true;
		yield return new WaitForSeconds(3f);
		_nextLevelText.enabled = false;
	}
}
