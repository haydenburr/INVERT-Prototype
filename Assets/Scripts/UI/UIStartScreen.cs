using UnityEngine;
using System.Collections;

public class UIStartScreen : MonoBehaviour {

	public void Show ()
	{
		gameObject.SetActive (true);
	}
	
	public void Hide ()
	{
		gameObject.SetActive (false);
	}
}
