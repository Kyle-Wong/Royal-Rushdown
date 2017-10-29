
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    public static float timer = 0;
    public int nextNote;
    public List<GameObject> lister;
    public static bool occupied = false;
    public static bool hitReady;
    private GameObject closestEnemy;
    public static bool inputThisFrame;
    public float knockBackVelocity = 0;
    // Use this for initialization
    void Start()
    {
        hitReady = true;
        lister = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        occupied = true;
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            insertGameObject(other.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            occupied = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        occupied = false;
        if (!collision.gameObject.Equals(null))
        {
            lister.Remove(collision.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!hitReady) { 
        timer = timer + Time.deltaTime;
        }

        if (timer > .25)
        {
            hitReady = true;
            timer = 0;
        }

        if (lister.Count > 0)
        {
            closestEnemy = getClosestEnemy();
            nextNote = closestEnemy.GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0 && hitReady)
            {
                closestEnemy.GetComponent<ColorLerp>().startColorChange();
                closestEnemy.GetComponent<NoteManager>().removeFront();
                knockBackAllEnemies();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextNote == 1 && hitReady)
            {
                closestEnemy.GetComponent<ColorLerp>().startColorChange();
                closestEnemy.GetComponent<NoteManager>().removeFront();
                knockBackAllEnemies();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextNote == 2 && hitReady)
            {
                closestEnemy.GetComponent<ColorLerp>().startColorChange();
                closestEnemy.GetComponent<NoteManager>().removeFront();
                knockBackAllEnemies();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextNote == 3 && hitReady)
            {
                closestEnemy.GetComponent<ColorLerp>().startColorChange();
                closestEnemy.GetComponent<NoteManager>().removeFront();
                knockBackAllEnemies();
            }
            else if (LungeTrigger.destroyNext)
            {
                closestEnemy.GetComponent<ColorLerp>().startColorChange();
                LungeTrigger.destroyNext = false;
                //knockBackAllEnemies();
            }
            else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                closestEnemy.GetComponent<NoteManager>().flashColor(Color.red, Color.white, 0.15f, 0.3f);
            }
            
            if (closestEnemy.gameObject.GetComponent<NoteManager>().empty())
            {
                GameObject boneExplosion = (GameObject)Instantiate(Resources.Load("BoneExplosion"));
                boneExplosion.transform.position = closestEnemy.transform.position;
                boneExplosion.GetComponent<ParticleExplosion>().explode(15, 2);
                Spawn.enemyList.Remove(closestEnemy);
                Destroy(closestEnemy);
            }
        }
    }
    public GameObject getClosestEnemy()
    {
        float min = 10000000;
        int index = 0;
        for (int i = 0; i < lister.Count; ++i)
        {
            if (lister[i].transform.position.x < min)
            {
                min = lister[i].transform.position.x;
                index = i;
            }
        }
        return lister[index];
    }
    public void insertGameObject(GameObject obj)
    {
        //front->lowestX->highestX->end

        for (int i = 0; i < lister.Count; ++i)
        {
            if (obj.transform.position.x < lister[i].transform.position.x)
            {
                lister.Insert(i, obj);
                return;
            }
        }
        lister.Add(obj);
    }
    public void knockBackAllEnemies()
    {
        int enemyCount = Spawn.enemyList.Count;
        for(int i = 0; i < enemyCount; ++i)
        {
            Spawn.enemyList[i].GetComponent<MoveLeft>().speed = -knockBackVelocity;
        }
    }
}
