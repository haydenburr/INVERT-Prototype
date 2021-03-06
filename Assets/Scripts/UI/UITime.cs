﻿using UnityEngine;
using System.Collections;

public class UITime : MonoBehaviour {

	public UnityEngine.UI.Text text;
	public UnityEngine.UI.Text text2;
	
	public Color black;
	public Color white;

	public void SetTime (float time)
	{
		text.text = time.ToString ("0.00s");
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
