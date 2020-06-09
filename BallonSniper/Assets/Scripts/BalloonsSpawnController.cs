using UnityEngine;
using System.Collections;

public class BalloonsSpawnController : MonoBehaviour
{
	[SerializeField] private SpawnOptionsScript spawnOptions = null;
	private int _numOfBalloonsToSpawn = 5;
	private float _intervalForSpawn = 20f;

	private GameObject _spawnedBalloon;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private void SpawnBallons()
	{
		for (int i = 0; i < _numOfBalloonsToSpawn; i++)
		{
			_spawnedBalloon = spawnOptions.SpawnBallon();
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
}
