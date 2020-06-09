using UnityEngine;

public class BalloonsSpawnController : MonoBehaviour
{
	[SerializeField] private SpawnOptionsScript spawnOptions = null;
	private int _numOfFirstBalloons = 5;

	private GameObject _spawnedBalloon;

	private void Start()
	{
		SpawnFirstBallons();
	}

	private void SpawnFirstBallons()
	{
		for (int i = 0; i < _numOfFirstBalloons; i++)
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
}
