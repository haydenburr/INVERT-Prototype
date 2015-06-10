using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private GameController gameController;
	public UIScoreMinus scoreMinus;

	public SpriteRenderer spriteRenderer;	
	public Sprite Black;
	public Sprite White;
	public string spriteColour;

	private float gameoverTime = 2f;
	private float gameoverTimer;
	public bool hasBeenHit = false;

	public bool notOnSide = false;
	public int maxInvertCount = 3;
	public int invertCount;

	//lower and upper collision detection
	public Transform playerPosition;
	
	void Start ()
	{
		gameController = GameObject.FindObjectOfType<GameController> ();
		invertCount = maxInvertCount;

		spriteColour = gameController.currentColour;
		UpdateSprite ();
	}
	
	void Update ()
	{
		if (spriteColour != gameController.currentColour)
		{
			spriteColour = gameController.currentColour;
			UpdateSprite ();
		}

		if (playerPosition.position.y > 0 && playerPosition.position.y < 4) //need to get y position of upper/lower
		{
			notOnSide = true;;
		}

		if (invertCount != 3 && notOnSide == true)
		{
			if (playerPosition.position.y >= 4.3f || playerPosition.position.y <= -0.7f) //need to get y position of upper/lower
			{
				notOnSide = false;
				invertCount = maxInvertCount;
			}
		}


		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			if (hasBeenHit == false)
			{
				if (invertCount != 0)
				{
					Invert();
				}
			}
		}

		if (gameoverTimer > 0)
		{
			gameoverTimer -= Time.deltaTime;
			if (gameoverTimer <= 0)
			{
				gameController.GameOver ();
			}
		}
	}

	void Invert ()
	{
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, (rigidbody2D.velocity.y / 2));
		rigidbody2D.gravityScale = -(rigidbody2D.gravityScale);

		//change the sprites
		gameController.Invert ();

		//scoring
		if (gameController.gameScore != 0 && invertCount != 3)
		{
			gameController.gameScore -= 1;
			scoreMinus.Show ();
		}

		invertCount -= 1;
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

	void Hit ()
	{
		if (hasBeenHit == false)
		{
			gameoverTimer = gameoverTime;
			hasBeenHit = true;
		}
	}
}
