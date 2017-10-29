using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour {

    public double distance = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        distance += 17.8816 * Time.deltaTime;
        GetComponent<Text>().text = "Distance Run: " + (int)distance + "m";
    }
}
