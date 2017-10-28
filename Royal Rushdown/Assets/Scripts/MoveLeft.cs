using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
	
	public float speed = -5;
	public int delete_at = 0;

	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.x < delete_at)
		{
			Destroy (gameObject);
		}
		else{
			transform.position = new Vector2 (transform.position.x + (speed*Time.deltaTime*GameController.globalSpeed), transform.position.y);
		
		}


	}
}
