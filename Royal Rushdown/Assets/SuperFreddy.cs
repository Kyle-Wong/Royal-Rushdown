using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperFreddy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Spawn.enemyList.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
