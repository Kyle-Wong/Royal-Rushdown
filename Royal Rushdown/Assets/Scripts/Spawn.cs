using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject spawnPrefab;
	// Use this for initialization
	void Start () {
		SpawnMe ();
	}

	public void SpawnMe(){
		Instantiate(spawnPrefab, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		SpawnMe ();
	}
}
