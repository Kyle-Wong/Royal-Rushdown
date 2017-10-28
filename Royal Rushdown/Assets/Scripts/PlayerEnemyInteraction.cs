using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyInteraction : MonoBehaviour {
	float health = 110;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame;
	void Update () {
		if (health < 100)
		{
			health = Mathf.Clamp (health + Time.deltaTime*5, 0, 100);
		}

	}
		
	void OnTriggerEnter2D(Collider2D other) {
		if (health == 110) {
			health -= 50;
		} else {
			health -= (health * .3f);
		}

		if (health < 10) {
			Destroy (gameObject);
		} 
	}

}
