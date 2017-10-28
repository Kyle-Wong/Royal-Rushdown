using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour {

    // Use this for initialization
    public int particlesEmitted =15;
    public float lifeTime = 2;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void explode(int numParticles, float objLifeTime)
    {
        GetComponent<ParticleSystem>().Play();
        GetComponent<ParticleSystem>().Emit(numParticles);
        GetComponent<ParticleSystem>().Stop();

        Destroy(gameObject, objLifeTime);
    }
}
