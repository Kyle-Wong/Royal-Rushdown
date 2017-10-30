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
            GameObject boneExplosion = (GameObject)Instantiate(Resources.Load("BoneExplosion"));
            boneExplosion.transform.position = other.gameObject.transform.position + Vector3.down * 0.5f;
            boneExplosion.GetComponent<ParticleExplosion>().explode(20, 3);
            Destroy(other.gameObject);
            AttackZone.combo++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
