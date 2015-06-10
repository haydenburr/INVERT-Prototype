using UnityEngine;
using System.Collections;

public class UIRestartButton : MonoBehaviour {

	public void OnClick()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
