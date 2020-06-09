using UnityEngine;
using UnityEngine.UI;

public class PalletSelector : MonoBehaviour
{
	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void SelectPallet(Image palleteImage)
	{
		gameObject.GetComponent<SpriteRenderer>().color = palleteImage.color;
		gameObject.SetActive(true);
	}
}
