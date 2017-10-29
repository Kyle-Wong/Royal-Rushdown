 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyInteraction : MonoBehaviour {
	public float health = 110;
	SpriteRenderer render;
	Color initialCol;
	public GameController controller;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		initialCol = render.color;
	}
	
	// Update is called once per frame;
	void Update () {
		if (health < 100)
		{
			health = Mathf.Clamp (health + Time.deltaTime*3, 0, 100);
		}

	}
		
	void OnTriggerEnter2D(Collider2D other) {
		StartCoroutine(gotHit());
        GameController.defaultSpeed *= 0.75f;
		if (health == 110) {
			health -= 50;
		} else {
			health -= (health * .3f);
		}

		if (health < 10) {
			print ("before state is changed");
			controller.setGameState (2);
			print ("state should be changed");
			Destroy (gameObject);
		} 
	}

	IEnumerator gotHit()
	{
        AttackZone.combo = 0;
		render.color = Color.Lerp (initialCol, Color.red, .25f);
		yield return new WaitForSeconds(.25f);
		render.color = Color.Lerp (initialCol, Color.red, 0);
	
	}

}
