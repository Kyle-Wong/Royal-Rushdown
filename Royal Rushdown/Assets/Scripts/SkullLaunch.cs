using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullLaunch : MonoBehaviour {

    // Use this for initialization
    public float minXVel;
    public float maxXVel;
    public float minYVel;
    public float maxYVel;
    public float angularSpeed;
    public float lifeTime;
    
	void Start () {
        Destroy(gameObject, lifeTime);
        float xVel = minXVel + Random.value * (maxXVel - minXVel);
        float yVel = minYVel + Random.value * (maxYVel - minYVel);
        
        GetComponent<Rigidbody2D>().velocity = new Vector3(xVel, yVel, 0);
        int posOrNeg = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody2D>().angularVelocity = posOrNeg * Random.value * angularSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
