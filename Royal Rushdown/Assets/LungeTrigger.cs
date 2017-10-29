//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class LungeTrigger : MonoBehaviour {
//
//    public int nextNote;
//    public List<GameObject> lister;
//    public static bool correctInput = false;
//    public static bool destroyNext = false;
//    private GameObject closestEnemy;
//
//    // Use this for initialization
//    void Start () {
//        lister = new List<GameObject>();
//
//    }
//
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag("Enemy") == true)
//        {
//            insertGameObject(other.gameObject);
//        }
//
//    }
//
//    private void OnTriggerStay2D(Collider2D other)
//    {
//
//        
//    }
//
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (!collision.gameObject.Equals(null))
//        {
//            correctInput = false;
//            lister.Remove(collision.gameObject);
//            GameController.globalSpeed = 1;
//        }
//
//    }
//
//    // Update is called once per frame
//    void Update() {
//        if (lister.Count >= 1)
//        {
//            if (lister[0].gameObject.Equals(null))
//            {
//                lister.RemoveAt(0);
//            }
//        }
//        if (lister.Count >= 1 && !FightZone.occupied)
//        {
//            closestEnemy = getClosestEnemy();
//            nextNote = closestEnemy.GetComponent<NoteManager>().getNextNoteDirection();
//            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
//            {
//                correctInput = true;
//                if (!FightZone.occupied)
//                {
//                    destroyNext = true;
//                    closestEnemy.GetComponent<NoteManager>().removeFront();
//
//                }
//            }
//            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextNote == 1)
//            {
//                correctInput = true;
//                if (!FightZone.occupied)
//                {
//                    destroyNext = true;
//                    closestEnemy.GetComponent<NoteManager>().removeFront();
//
//                }
//            }
//            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextNote == 2)
//            {
//                correctInput = true;
//                if (!FightZone.occupied)
//                {
//                    destroyNext = true;
//                    closestEnemy.GetComponent<NoteManager>().removeFront();
//
//                }
//            }
//            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextNote == 3)
//            {
//                correctInput = true;
//                if (!FightZone.occupied)
//                {
//                    destroyNext = true;
//                    closestEnemy.GetComponent<NoteManager>().removeFront();
//
//                }
//            }
//
//            if (correctInput && !FightZone.occupied)
//            {
//                GameController.globalSpeed = 10;
//            }
//            else
//            {
//                GameController.globalSpeed = 1;
//            }
//        }
//        
//    }
//	public GameObject getClosestEnemy()
//    {
//        float min = 10000000;
//        int index = 0;
//        for(int i = 0; i < lister.Count; ++i)
//        {
//            if(lister[i].transform.position.x < min)
//            {
//                min = lister[i].transform.position.x;
//                index = i;
//            }
//        }
//        return lister[index];
//    }
//    public void insertGameObject(GameObject obj)
//    {   
//        //front->lowestX->highestX->end
//
//        for(int i = 0; i < lister.Count; ++i)
//        {
//            if(obj.transform.position.x < lister[i].transform.position.x)
//            {
//                lister.Insert(i, obj);
//                return;
//            }
//        }
//        lister.Add(obj);
//    }
//
//}
