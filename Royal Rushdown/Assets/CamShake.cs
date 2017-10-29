using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {

    float xShake = 0;
    float yShake = 0;
    float xStart = 0;
    float yStart = 0;
    float timer = 0;
    public static bool shaking;

	// Use this for initialization
	void Start () {
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
        
	}

    // Update is called once per frame
    void Update() {


        if (shaking == true)
        {
            if (xShake == 0)
            {
                xShake = Random.Range(-.2f, .2f);
                yShake = Random.Range(-.2f, .2f);
            }

            timer += timer + Time.deltaTime;
            gameObject.transform.position = new Vector3(xStart + xShake, yStart+ yShake, -10);
        }
        if (timer > .1)
        {
            timer = 0;
            shaking = false;
        }

        if (shaking == false)
        {
            gameObject.transform.position = new Vector3(xStart, yStart, -10);

        }
        else
        {
            xShake = 0;
            yShake = 0;
        }
    }
	
}
