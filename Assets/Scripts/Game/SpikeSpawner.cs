using UnityEngine;
using System.Collections;

public class SpikeSpawner : MonoBehaviour {

	private GameController gameController;
	public Spike spikePrefab;
	public SpikeDouble doubleSpikePrefab;
	public SpikeTriple tripleSpikePrefab;

	public string spawnType;
	private string singleSpawn = "Single";
	private string doubleSpawn = "Double";
	private string tripleSpawn = "Triple";
	private float spawnDelay;
	private float startDelay;
	public float startTimer = 3f;

	void Start ()
	{
		gameController = GameObject.FindObjectOfType<GameController> ();
		startDelay = startTimer;
		spawnType = singleSpawn;
	}
	
	void Update ()
	{
		if (startDelay > 0)
		{
			startDelay -= Time.deltaTime;
		}

		if (gameController.gameFinished != true)
		{
			if (startDelay <= 0)
			{
				SpikeSpawn();
				SpawnTime();
			}
		}
	}

	public void SpikeSpawn ()
	{
		if (gameController.gameTime >= 10 && gameController.gameTime < 30)
		{
			ChanceRoll();
			if (spawnType == doubleSpawn)
			{
				SpikeDouble newSpike = GameObject.Instantiate (doubleSpikePrefab) as SpikeDouble;
				newSpike.transform.position = transform.position;
			}
			else
			{
				Spike newSpike = GameObject.Instantiate (spikePrefab) as Spike;
				newSpike.transform.position = transform.position;
			}
		}
		else if (gameController.gameTime >= 30)
		{
			ChanceRoll();
			if (spawnType == tripleSpawn)
			{
				SpikeTriple newSpike = GameObject.Instantiate (tripleSpikePrefab) as SpikeTriple;
				newSpike.transform.position = transform.position;
			}
			else if (spawnType == doubleSpawn)
			{
				SpikeDouble newSpike = GameObject.Instantiate (doubleSpikePrefab) as SpikeDouble;
				newSpike.transform.position = transform.position;
			}
			else
			{
				Spike newSpike = GameObject.Instantiate (spikePrefab) as Spike;
				newSpike.transform.position = transform.position;
			}
		}
		else
		{
			Spike newSpike = GameObject.Instantiate (spikePrefab) as Spike;
			newSpike.transform.position = transform.position;
		}

	}
	
	void SpawnTime ()
	{
		int[] time = new int[3] { 1, 2, 3 };
		int timeResult = time[Random.Range(0, time.Length)];
		
		if (timeResult == 1)
		{
			spawnDelay = 1.0f;
		}

		if (timeResult == 2)
		{
			spawnDelay = 1.5f;
		}

		if (timeResult == 3)
		{
			spawnDelay = 2.0f;
		}

		startDelay = spawnDelay;
	}

	void ChanceRoll ()
	{
		int[] time = new int[3] { 1, 2, 3 };
		int timeResult = time[Random.Range(0, time.Length)];
		
		if (timeResult == 1)
		{
			spawnType = singleSpawn;
			Debug.Log ("Single Roll");
		}
		
		if (timeResult == 2)
		{
			spawnType = doubleSpawn;
			Debug.Log ("Double Roll");
		}
		
		if (timeResult == 3)
		{
			spawnType = tripleSpawn;
			Debug.Log ("Tripple Roll");
		}
	}
}
