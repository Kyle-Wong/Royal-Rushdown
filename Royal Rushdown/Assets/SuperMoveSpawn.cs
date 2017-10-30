using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMoveSpawn : MonoBehaviour
{

    int freddyCount = 0;

    float timer = 0f;
    public static bool superUsed;
    public GameObject spawnPrefab;


    // Use this for initialization
    void Start()
    {
        superUsed = false;
    }

    void SpawnMe()
    {
        GameObject newFreddy = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
        newFreddy.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (freddyCount < 10 && superUsed)
        {
            timer += Time.deltaTime;
            if (timer > .075)
            {
                SpawnMe();
                timer = 0;
                freddyCount++;
            }
           
        }
        else if(freddyCount >= 10)
        {
            superUsed = false;
            AttackZone.superCharge = 0;
            freddyCount = 0;
        }
    }
}
