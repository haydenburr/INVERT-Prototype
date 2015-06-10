using UnityEngine;
using System.Collections;

public class UIInvertCount : MonoBehaviour {

	public UnityEngine.UI.Text text;
	public UnityEngine.UI.Text text2;

	public Color black;
	public Color white;
		
	public void SetCount (float count)
	{
		text.text = count.ToString ("0");
	}

	public void SetColour (string colour)
	{
		if (colour == "Black")
		{
			text.color = black;
			text2.color = black;
		}
		else if (colour == "White")
		{
			text.color = white;
			text2.color = white;
		}
	}
}
