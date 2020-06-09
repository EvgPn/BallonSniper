using UnityEngine;

public class BoundsPositionsCorrector : MonoBehaviour
{
	[SerializeField] private BoxCollider2D[] _boundsColliders = new BoxCollider2D[4];
	[SerializeField] private GameObject _bottomField = null;

	private Vector2 _screenLimits;

	private void Start()
	{
		SetLimitsOfScreen();
		SetNewPositionsForBounds();
	}

	private void SetLimitsOfScreen()
	{
		_screenLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		_screenLimits.x += 0.5f;
		_screenLimits.y += 0.5f;
	}

	private void SetNewPositionsForBounds()
	{
		_boundsColliders[0].offset = new Vector2(_screenLimits.x, 0);
		_boundsColliders[1].offset = new Vector2(_screenLimits.x * -1, 0);
		_boundsColliders[2].offset = new Vector2(0, _screenLimits.y);
		_boundsColliders[3].offset = new Vector2(0, _bottomField.transform.position.y - 0.5f);
	}
}
