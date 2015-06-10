using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private GameController gameController;
	public SpriteRenderer spriteRenderer;
	
	public Sprite Black;
	public Sprite White;
	
	public string spriteColour;

	// Use this for initialization
	void Start ()
	{
		gameController = GameObject.FindObjectOfType<GameController> ();

		spriteColour = gameController.currentColour;
		
		UpdateSprite ();
	}
	
	// Update is called once per frame
	void Update ()
	{
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
}
