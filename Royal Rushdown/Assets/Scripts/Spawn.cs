using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	float timer = 0f;
	float min = .5f;
	float range = 3f;
	float totalTime = 0;
	float spawnTime;
	public GameObject spawnPrefab;
	// Use this for initialization
	void Start () {
		spawnTime = min+range;
		//InvokeRepeating ("decreaseRange", 3f, 3);
		StartCoroutine(decreaseRange());
	}

	void SpawnMe(){
		Instantiate(spawnPrefab, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			SpawnMe ();
			timer = 0f;
		}
		totalTime += Time.deltaTime;
	}

	IEnumerator decreaseRange()
	{
		while (range > 0) {
			range -= .3f;
			spawnTime = min + range;
			yield return new WaitForSeconds (3.33f);
		}
	}
}
