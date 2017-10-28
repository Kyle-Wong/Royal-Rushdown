using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopObject : MonoBehaviour {

    // Use this for initialization
    public float speed;
    private float spriteWidth;
    public Camera cam;
	void Start () {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * speed * Time.deltaTime * GameController.globalSpeed;
        
	}
}
