using UnityEngine;
using System.Collections;

public class TitleController : MonoBehaviour {

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
