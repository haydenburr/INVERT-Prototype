using UnityEngine;
using System.Collections;

public class UIInstructionScreen : MonoBehaviour {

	public void Show ()
	{
		gameObject.SetActive (true);
	}
	
	public void Hide ()
	{
		gameObject.SetActive (false);
	}
}
