using UnityEngine;
using System.Collections;

public class UIBackButton : MonoBehaviour {

	public UIInstructionScreen instructionScreen;
	
	void start ()
	{
		instructionScreen = GameObject.FindObjectOfType<UIInstructionScreen> ();
	}
	
	public void OnClick()
	{
		instructionScreen.Hide ();
	}
}
