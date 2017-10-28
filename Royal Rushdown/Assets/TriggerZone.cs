using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {

    public int nextNote;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
           
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            nextNote = other.gameObject.GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
            {
                other.gameObject.GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextNote == 1)
            {
                other.gameObject.GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextNote == 2)
            {
                other.gameObject.GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextNote == 3)
            {
                other.gameObject.GetComponent<NoteManager>().removeFront();
            }
            if (other.gameObject.GetComponent<NoteManager>().empty())
            {
                Destroy(other.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
