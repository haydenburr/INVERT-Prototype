using UnityEngine;
using System.Collections;

public class UIScorePlus : MonoBehaviour {

	public bool shown;
	public float time = 0.25f;
	public float timer;
	
	public void Show ()
	{
		gameObject.SetActive (true);
		shown = true;
	}
	
	public void Hide ()
	{
		shown = false;
		timer = time;
		gameObject.SetActive (false);
	}
	
	void Start ()
	{
		timer = time;
	}
	
	void Update ()
	{
		if (shown == true && timer > 0)
		{
			timer -= Time.deltaTime;
			if (timer <= 0)
			{
				Hide ();
			}
		}
	}
}
