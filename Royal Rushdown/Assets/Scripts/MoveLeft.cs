using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
	
	public float speed = 5;
	public int delete_at = 0;
    public float acceleration = 0;
    public float maxSpeed = 5;
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.x < delete_at)
		{
			Destroy (gameObject);
		}
		else{
            if (GameController.gameState == GameController.GameState.InGame)
            {
                transform.position += Vector3.left * speed * GameController.globalSpeed * Time.deltaTime;
                if(speed < maxSpeed)
                {
                    speed += acceleration * GameController.globalSpeed * Time.deltaTime;
                }
            }
		    
		}


	}
}
