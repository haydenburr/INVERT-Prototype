using UnityEngine;
using System.Collections;

public class UILoadLevel : MonoBehaviour {

	public string sceneName;

	public void OnClick()
	{
		Application.LoadLevel (sceneName);
	}

}
