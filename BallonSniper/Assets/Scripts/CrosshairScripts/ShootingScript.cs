using System.Collections;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
	public delegate void ShootCallBack();
	public static event ShootCallBack AddScore;

	[SerializeField] private BalloonsCounter _balloonsCounter = null;
	[SerializeField] private LayerMask _balloonLayerMask = new LayerMask();
	private float _overlapCircleRadius = 0.1f;
	private Collider2D _balloonCollider;

	private void Update()
	{
		ShootOnTouch();
	}

	private void ShootOnTouch()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			CheckTouchOnCrosshair(touch, touchPos);
		}

	}

	private void CheckTouchOnCrosshair(Touch touch, Vector2 touchPos)
	{
		if (touch.phase == TouchPhase.Began && GetComponent<Collider2D>() == Physics2D.OverlapCircle(touchPos, _overlapCircleRadius))
		{
			CheckBalloonUnderCrosshair();
		}
	}

	private void CheckBalloonUnderCrosshair()
	{
		_balloonCollider = Physics2D.OverlapCircle(transform.position, _overlapCircleRadius, _balloonLayerMask.value);

		if (_balloonCollider != null && _balloonCollider.gameObject.name == "balloon")
		{
			MakeShoot();
		}
	}

	private void MakeShoot()
	{
		if (GetComponent<SpriteRenderer>().color == _balloonCollider.gameObject.GetComponent<SpriteRenderer>().color)
		{
			Destroy(_balloonCollider.gameObject);
			_balloonsCounter.BalloonsInScene--;
			AddScore?.Invoke();
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.red;
			StartCoroutine(Blinking(1f, 0.2f));
		}
	}

	private IEnumerator Blinking(float duration, float blinkTime)
	{
		bool activeCrosshair = true;

		while (duration > 0f)
		{
			activeCrosshair = !activeCrosshair;
			GetComponent<SpriteRenderer>().enabled = activeCrosshair;
			yield return new WaitForSeconds(blinkTime);
			duration -= blinkTime;
		}

		gameObject.SetActive(false);
	}
}
