using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
	
	public float speed = 5;
	public int delete_at = 0;
    public float acceleration = 0;
    public float maxSpeed = 5;
    public float startPos = 0;
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
<<<<<<< Updated upstream
        if(gameObject.transform.position.x < delete_at)
		{
            Spawn.enemyList.Remove(gameObject);
=======
//        if (FightZone.knockback)
//        {
//            //if(startPos == 0)
//            //{
//            //    startPos = gameObject.transform.position.x;
//            //}
//            //if(gameObject.transform.position.x < startPos - 5000)
//            //{
//            //    transform.position += Vector3.left * speed * Time.deltaTime * GameController.globalSpeed * 4;
//            //}
//            //else
//            //{
//            //    startPos = 0;
//            //    FightZone.knockback = false;
//            //}
//            speed = -5;
//            FightZone.knockback = false;
//        }
//		else if(gameObject.transform.position.x < delete_at)
//		{
//			Destroy (gameObject);
//		}
		if (gameObject.transform.position.x < delete_at) {
>>>>>>> Stashed changes
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
