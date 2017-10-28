using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeTrigger : MonoBehaviour {

    public int nextNote;
    public List<GameObject> listo;
    public bool correctInput = false;


    // Use this for initialization
    void Start () {
        listo = new List<GameObject>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            listo.Add(other.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") == true)
        {

            print("Speedup");
            GameController.globalSpeed = 3;
            //print(listo.Count);
            //nextNote = listo[0].GetComponent<NoteManager>().getNextNoteDirection();
            //if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
            //{
            //    correctInput = true;
            //}
            //else if (Input.GetKey(KeyCode.RightArrow) && nextNote == 1)
            //{
            //    correctInput = true;
            //}
            //else if (Input.GetKey(KeyCode.DownArrow) && nextNote == 2)
            //{
            //    correctInput = true;
            //}
            //else if (Input.GetKey(KeyCode.LeftArrow) && nextNote == 3)
            //{
            //    correctInput = true;
            //}

            //if (correctInput)
            //{
            //    GameController.globalSpeed = 3; 
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.Equals(null))
        {
            //listo.RemoveAt(0);
            print("Exit");
            GameController.globalSpeed = 1;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
