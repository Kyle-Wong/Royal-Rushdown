using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
