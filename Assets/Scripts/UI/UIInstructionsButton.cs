using UnityEngine;
using System.Collections;

public class UIInstructionsButton : MonoBehaviour {

	public UIInstructionScreen instructionScreen;

	void start ()
	{
		instructionScreen = GameObject.FindObjectOfType<UIInstructionScreen> ();
	}

	public void OnClick()
	{
		instructionScreen.Show ();
	}
}
