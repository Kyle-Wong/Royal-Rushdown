using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour {

    // Use this for initialization
    public float speed;
    private float spriteWidth;
	void Start () {
        spriteWidth = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime * GameController.globalSpeed;
        if(transform.position.x < -25)
        {
            transform.position += Vector3.right * spriteWidth;
        }
	}
}
