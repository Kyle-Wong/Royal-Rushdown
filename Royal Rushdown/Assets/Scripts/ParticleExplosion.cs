using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour {

    // Use this for initialization
    public int particlesEmitted;
    public float lifeTime;
	void Start () {
        explode(particlesEmitted, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void explode(int numParticles, float objLifeTime)
    {
        GetComponent<ParticleSystem>().Emit(numParticles);
        Destroy(gameObject, objLifeTime);
    }
}
