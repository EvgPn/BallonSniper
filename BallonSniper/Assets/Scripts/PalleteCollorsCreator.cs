using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalleteCollorsCreator : MonoBehaviour
{
	[SerializeField] private List<GameObject> _palletesButtons = new List<GameObject>();
	[SerializeField] private List<Color> _colors = new List<Color>();
	public List<Color> GetColorsFromPalletes { get { return _colors; } }
	
	private void Start()
	{
		SetPalletesColors();
	}

	private void SetPalletesColors()
	{
		int counterForCollors = 0;

		foreach (GameObject pallete in _palletesButtons)
		{
			pallete.GetComponent<Image>().color = _colors[counterForCollors];
			counterForCollors++;
		}
	}
}
