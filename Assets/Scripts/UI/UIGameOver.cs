using UnityEngine;
using System.Collections;

public class UIGameOver : MonoBehaviour {

	public UnityEngine.UI.Text score;
	public UnityEngine.UI.Text time;
	public UnityEngine.UI.Text bestScore;
	public UnityEngine.UI.Text bestTime;

	public void Show (int endScore, float endTime, int endBestScore, float endBestTime)
	{
		gameObject.SetActive (true);

		score.text = endScore.ToString ("000");
		time.text = endTime.ToString ("0.00s");
		bestScore.text = endBestScore.ToString ("000");
		bestTime.text = endBestTime.ToString ("0.00s");
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
