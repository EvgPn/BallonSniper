using UnityEngine;

public class BalloonController : MonoBehaviour
{
	private const float _defaultBalloonVelocity = 2f;
	private float _balloonVelocity;
	private Rigidbody2D _balloonRigidbody;

	private Vector2[] _moveDirections = new Vector2[4] { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
	private Vector2 _startDirection;

	private void OnEnable()
	{
		LevelsManager.ChangeBalloonsVelocity += SetNewVelocity;
	}

	private void Start()
	{
		_balloonVelocity = _defaultBalloonVelocity;
		_balloonRigidbody = GetComponent<Rigidbody2D>();
		SetStartBalloonVelocity();
	}

	private void FixedUpdate()
	{
		_balloonRigidbody.velocity = Vector2.ClampMagnitude(_balloonRigidbody.velocity, _balloonVelocity);
		if (_balloonRigidbody.velocity.magnitude < _balloonVelocity)
		{
			_balloonRigidbody.velocity *= 1.05f;
		}
	}

	private void SetStartBalloonVelocity()
	{
		int directionIndex = Random.Range(0, _moveDirections.Length);
		_startDirection = _moveDirections[directionIndex];

		_balloonRigidbody.velocity = _startDirection * _balloonVelocity;
	}

	private void SetNewVelocity(float velocity)
	{
		_balloonVelocity = _defaultBalloonVelocity * velocity;
	}
}
