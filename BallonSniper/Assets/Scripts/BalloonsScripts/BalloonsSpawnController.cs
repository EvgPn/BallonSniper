using UnityEngine;
using System.Collections;

public class BalloonsSpawnController : MonoBehaviour
{
	[SerializeField] private BalloonsCounter _balloonsCounter = null;
	[SerializeField] private SpawnOptionsScript spawnOptions = null;
	private int _numOfBalloonsToSpawn = 5;
	public float _intervalForSpawn = 20f;

	private GameObject _spawnedBalloon;

	private void OnEnable()
	{
		LevelsManager.ChangeSpawnInterval += SetNewSpawnInterval;
	}

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private void SpawnBallons()
	{
		for (int i = 0; i < _numOfBalloonsToSpawn; i++)
		{
			_spawnedBalloon = spawnOptions.SpawnBallon();
			_balloonsCounter.BalloonsInScene++;
			PreventBalloonsOverlaping();
		}
	}

	private void PreventBalloonsOverlaping()
	{
		CircleCollider2D balloonCollider = _spawnedBalloon.GetComponent<CircleCollider2D>();
		balloonCollider.enabled = false;

		while (Physics2D.OverlapCircle(balloonCollider.bounds.center, balloonCollider.radius))
		{
			_spawnedBalloon.transform.position = spawnOptions.ChooseRandomPosition();
		}

		balloonCollider.enabled = true;
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			SpawnBallons();
			yield return new WaitForSeconds(_intervalForSpawn);
		}
	}

	private void SetNewSpawnInterval(float newInterval)
	{
		_intervalForSpawn = newInterval;
	}
}
