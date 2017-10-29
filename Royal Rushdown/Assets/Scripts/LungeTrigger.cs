using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeTrigger : MonoBehaviour {

    public int nextNote;
    public static List<GameObject> lister;
    public static bool correctInput = false;
    public static bool destroyNext = false;
    private GameObject closestEnemy;
    private bool lungedThisFrame = false;
    // Use this for initialization
    void Start () {
        lister = new List<GameObject>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            insertGameObject(other.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.Equals(null))
        {
            correctInput = false;
            lister.Remove(collision.gameObject);
        }

    }

    // Update is called once per frame
    void Update() {
        if (lister.Count >= 1)
        {
            if (lister[0].gameObject.Equals(null))
            {
                lister.RemoveAt(0);
            }
        }
        lungedThisFrame = false;
        if (lister.Count >= 1 && !FightZone.occupied && GameController.gameState == GameController.GameState.InGame && !FightZone.killThisFrame)
        {

            FightZone.killThisFrame = false;
            closestEnemy = getClosestEnemy();
            nextNote = closestEnemy.GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
            {
                if (!correctInput)
                {
                    lungedThisFrame = true;
                }
                correctInput = true;
                if (!FightZone.occupied)
                {
                    destroyNext = true;
                    closestEnemy.GetComponent<NoteManager>().removeFront();

                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextNote == 1)
            {
                if (!correctInput)
                {
                    lungedThisFrame = true;
                }
                correctInput = true;
                if (!FightZone.occupied)
                {
                    destroyNext = true;
                    closestEnemy.GetComponent<NoteManager>().removeFront();

                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextNote == 2)
            {
                if (!correctInput)
                {
                    lungedThisFrame = true;
                }
                correctInput = true;
                if (!FightZone.occupied)
                {
                    destroyNext = true;
                    closestEnemy.GetComponent<NoteManager>().removeFront();

                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextNote == 3)
            {
                if (!correctInput)
                {
                    lungedThisFrame = true;
                }
                correctInput = true;
                if (!FightZone.occupied)
                {
                    destroyNext = true;
                    closestEnemy.GetComponent<NoteManager>().removeFront();

                }
            }

            if (correctInput && !FightZone.occupied)
            {
                GameController.globalSpeed = 7;
                if (lungedThisFrame)
                {
                    int enemyCount = Spawn.enemyList.Count;
                    for (int i = 0; i < enemyCount; ++i)
                    {
                        Spawn.enemyList[i].GetComponent<MoveLeft>().speed = Mathf.Max(3, Spawn.enemyList[i].GetComponent<MoveLeft>().speed);
                    }
                }
            }
            else
            {
                GameController.globalSpeed = GameController.defaultSpeed;
            }
        }
        
    }
	public GameObject getClosestEnemy()
    {
        float min = 10000000;
        int index = 0;
        for(int i = 0; i < lister.Count; ++i)
        {
            if(lister[i].transform.position.x < min)
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

        for(int i = 0; i < lister.Count; ++i)
        {
            if(obj.transform.position.x < lister[i].transform.position.x)
            {
                lister.Insert(i, obj);
                return;
            }
        }
        lister.Add(obj);
    }

}
