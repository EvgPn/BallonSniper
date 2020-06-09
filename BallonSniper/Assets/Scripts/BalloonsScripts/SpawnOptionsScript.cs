using UnityEngine;
using System.Collections.Generic;

public class SpawnOptionsScript : MonoBehaviour
{
	[SerializeField] private GameObject _bottomField = null;
	[SerializeField] private GameObject _balloonPrefab = null;

	private float _minXSpawnPos;
	private float _maxXSpawnPos;
	private float _minYSpawnPos;
	private float _maxYSpawnPos;

	private List<Color> _balloonsColors = new List<Color>();

	private void Awake()
	{
		_balloonsColors = _bottomField.GetComponentInChildren<PalleteCollorsCreator>().GetColorsFromPalletes;

		SetSpawnPointsLimits();
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

	public GameObject SpawnBallon()
	{
		Vector2 position = ChooseRandomPosition();
		GameObject balloon = Instantiate(_balloonPrefab, position, Quaternion.identity);
		balloon.GetComponent<SpriteRenderer>().color = ChooseRadomBalloonColor();
		balloon.name = "balloon";
		return balloon;
	}

	public Vector2 ChooseRandomPosition()
	{
		Vector2 position = new Vector2();
		position.x = Random.Range(_minXSpawnPos, _maxXSpawnPos);
		position.y = Random.Range(_minYSpawnPos, _maxYSpawnPos);
		return position;
	}

	private Color ChooseRadomBalloonColor()
	{
		int indexOfBallon = Random.Range(0, _balloonsColors.Count);
		return _balloonsColors[indexOfBallon];
	}
}
