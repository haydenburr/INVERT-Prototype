using UnityEngine;
using System.Collections;

public class SpikeTriple : MonoBehaviour {

	private GameController gameController;
	private Player player;
	
	private bool givenPoints = false;
	
	public SpriteRenderer spriteRenderer;
	
	public Sprite Black;
	public Sprite White;
	
	public string spriteColour;
	public int spikeSpeed = 12;
	
	void Start ()
	{
		gameController = GameObject.FindObjectOfType<GameController> ();
		player = GameObject.FindObjectOfType<Player> ();
		spriteColour = gameController.currentColour;
		
		UpdateSprite ();
	}
	
	void Update ()
	{
		transform.position -= transform.right * spikeSpeed * Time.deltaTime;
		
		if (transform.position.x <= -4.5 && givenPoints == false)
		{
			gameController.SpikeScore (3);
			givenPoints = true;
		}
		
		if (transform.position.x <= -10 && player.hasBeenHit == false)
		{
			GameObject.Destroy(gameObject);
		}
		
		if (spriteColour != gameController.currentColour)
		{
			spriteColour = gameController.currentColour;
			UpdateSprite ();
		}
	}
	
	void UpdateSprite ()
	{
		if (spriteColour == "Black")
		{
			spriteRenderer.sprite = Black;
		}
		else if (spriteColour == "White")
		{
			spriteRenderer.sprite = White;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		collision.gameObject.BroadcastMessage ("Hit", this, SendMessageOptions.DontRequireReceiver);
	}
}
