using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyInteraction : MonoBehaviour {
	float health = 110;
	SpriteRenderer render;
	Color initialCol;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		initialCol = render.color;

	}
	
	// Update is called once per frame;
	void Update () {
		if (health < 100)
		{
			health = Mathf.Clamp (health + Time.deltaTime*5, 0, 100);
		}

	}
		
	void OnTriggerEnter2D(Collider2D other) {
		StartCoroutine(gotHit());



		if (health == 110) {
			health -= 50;
		} else {
			health -= (health * .3f);
		}

		if (health < 10) {
			Destroy (gameObject);
		} 
	}

	IEnumerator gotHit()
	{
		render.color = Color.Lerp (initialCol, Color.red, .25f);
		yield return new WaitForSeconds(.25f);
		render.color = Color.Lerp (initialCol, Color.red, 0);
	
	}

}
