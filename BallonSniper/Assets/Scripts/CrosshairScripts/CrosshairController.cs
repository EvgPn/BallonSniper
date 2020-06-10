using UnityEngine;

public class CrosshairController : MonoBehaviour
{
	[SerializeField] private GameObject _bottomField = null;

	private Vector2 _screenBounds;
	private float _crosshairWidth;
	private float _crosshairHeight;

	private void Start()
	{
		_screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		_crosshairWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x - 0.2f;
		_crosshairHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
	}

	private void Update()
	{
		MoveCrosshairOnTouch();
		CheckBoundsOfMoveSpace();
	}

	private void MoveCrosshairOnTouch()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			if (touch.phase == TouchPhase.Moved)
			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

				RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

				if (GetComponent<Collider2D>() == hit.collider)
				{
					transform.position = new Vector3(touchPos.x, touchPos.y, -3f);
				}
			}
		}
	}

	private void CheckBoundsOfMoveSpace()
	{
		Vector3 crosshairPosition = transform.position;
		crosshairPosition.x = Mathf.Clamp(crosshairPosition.x, _screenBounds.x * -1 + _crosshairWidth, _screenBounds.x - _crosshairWidth);
		crosshairPosition.y = Mathf.Clamp(crosshairPosition.y, _bottomField.transform.position.y + _crosshairHeight, _screenBounds.y - _crosshairHeight);
		transform.position = crosshairPosition;
	}
}
