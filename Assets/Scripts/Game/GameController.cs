using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private static readonly string KEY_BEST_SCORE = "BEST_SCORE";
	private static readonly string KEY_BEST_TIME = "BEST_TIME";

	//===================================================================

	public UIInvertCount count;
	public UIScore score;
	public UITime time;
	public UIGameOver gameOver;
	public UIScorePlus scorePlus;

	public Player player;

	public float gameTime;
	public int gameScore;

	public int spikeSpeed = 12;

	public bool gameFinished = false;

	public int bestScore;
	public float bestTime;

	public string currentColour;

	//====================================================================

	void Start ()
	{
		currentColour = "Black";
	}

	void Update ()
	{
		if (gameFinished != true)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Screen.lockCursor = false;
				Application.LoadLevel ("Title");
			}
			
			gameTime += Time.deltaTime;
			time.SetTime (gameTime);
			count.SetCount (player.invertCount);
			score.SetScore (gameScore);
		}
	}

	public void Invert ()
	{
		if (currentColour == "Black")
		{
			time.SetColour (currentColour);
			count.SetColour (currentColour);
			score.SetColour (currentColour);
			currentColour = "White";
		}
		else
		{
			time.SetColour (currentColour);
			count.SetColour (currentColour);
			score.SetColour (currentColour);
			currentColour = "Black";
		}
	}
	
	public void SpikeScore (int score)
	{
		gameScore += score;
	}

	public void GameOver ()
	{
		gameFinished = true;
		Screen.lockCursor = false;

		bestScore = gameScore;
		bestTime = gameTime;
		if (PlayerPrefs.HasKey (KEY_BEST_SCORE))
		{
			var prevBestScore = PlayerPrefs.GetInt (KEY_BEST_SCORE);
			var prevBestTime = PlayerPrefs.GetFloat (KEY_BEST_TIME);
			if (gameScore > prevBestScore)
			{
				PlayerPrefs.SetInt (KEY_BEST_SCORE, gameScore);
				PlayerPrefs.SetFloat (KEY_BEST_TIME, gameTime);
			}
			else
			{
				bestScore = prevBestScore;
				bestTime = prevBestTime;
			}
		}
		else
		{
			PlayerPrefs.SetInt (KEY_BEST_SCORE, gameScore);
			PlayerPrefs.SetFloat (KEY_BEST_TIME, gameTime);
		}

		gameOver.Show (gameScore, gameTime, bestScore, bestTime);
	}
}
