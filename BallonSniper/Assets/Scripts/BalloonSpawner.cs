using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
	[SerializeField] private GameObject _bottomField = null;
	[SerializeField] private GameObject _balloonPrefab = null;

	private float _minXSpawnPos;
	private float _maxXSpawnPos;
	private float _minYSpawnPos;
	private float _maxYSpawnPos;

	private void Start()
	{
		SetSpawnPointsLimits();
		SpawnBallon();
	}

	private void SetSpawnPointsLimits()
	{
		Vector2 _limits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		_limits.x -= _balloonPrefab.GetComponent<SpriteRenderer>().bounds.extents.x;
		_limits.y -= _balloonPrefab.GetComponent<SpriteRenderer>().bounds.extents.y;

		_minXSpawnPos = _limits.x * -1;
		_maxXSpawnPos = _limits.x;
		_maxYSpawnPos = _limits.y;
		_minYSpawnPos = _bottomField.transform.position.y + _balloonPrefab.GetComponent<SpriteRenderer>().bounds.extents.y;
	}

	private void SpawnBallon()
	{
		Vector2 position = ChooseRandomPosition();
		Instantiate(_balloonPrefab, position, Quaternion.identity);
	}

	private Vector2 ChooseRandomPosition()
	{
		Vector2 position = new Vector2();
		position.x = Random.Range(_minXSpawnPos, _maxXSpawnPos);
		position.y = Random.Range(_minYSpawnPos, _maxYSpawnPos);
		return position;
	}
}
