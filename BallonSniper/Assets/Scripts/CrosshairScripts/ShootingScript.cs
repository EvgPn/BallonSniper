using System.Collections;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
	public delegate void ShootCallBack();
	public static event ShootCallBack AddScore;

	[SerializeField] private GameObject _poppingVFX = null;
	[SerializeField] private BalloonsCounter _balloonsCounter = null;
	[SerializeField] private LayerMask _balloonLayerMask = new LayerMask();

	private void Update()
	{
		ShootOnTouch();
	}

	private void ShootOnTouch()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			CheckTouchOnCrosshair(hit);
		}
	}

	private void CheckTouchOnCrosshair(RaycastHit2D hit)
	{
		if (hit.collider != null && hit.collider == GetComponent<Collider2D>())
		{
			CheckBalloonUnderCrosshair();
		}
	}

	private void CheckBalloonUnderCrosshair()
	{
		RaycastHit2D hitFromCrosshair = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.zero, 5f, _balloonLayerMask);
		if (hitFromCrosshair.collider != null && hitFromCrosshair.collider.gameObject.name == "balloon")
		{
			MakeShoot(hitFromCrosshair);
		}
	}

	private void MakeShoot(RaycastHit2D hitFromCrosshair)
	{
		if (GetComponent<SpriteRenderer>().color == hitFromCrosshair.collider.gameObject.GetComponent<SpriteRenderer>().color)
		{
			AddScore?.Invoke();
			GameObject popVFX = Instantiate(_poppingVFX, hitFromCrosshair.collider.gameObject.transform.position, Quaternion.identity);
			popVFX.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
			Destroy(popVFX, 0.5f);

			Destroy(hitFromCrosshair.collider.gameObject);
			_balloonsCounter.BalloonsInScene--;
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

		GetComponent<SpriteRenderer>().enabled = true;
		gameObject.SetActive(false);
	}
}
