using System.Collections;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
	public delegate void ChangeLevelParametrsCallBack(float newParametr);
	public static event ChangeLevelParametrsCallBack ChangeBalloonsVelocity;

	private void Start()
	{
		//StartCoroutine(Wait());
	}

	private IEnumerator Wait()
	{
		yield return new WaitForSeconds(5f);
		ChangeBalloonsVelocity?.Invoke(2f);
	}
}
