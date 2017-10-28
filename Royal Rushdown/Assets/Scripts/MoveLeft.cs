using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MoveLeft : MonoBehaviour {
	
	public int speed = -5;
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

			GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		}


	}
}
