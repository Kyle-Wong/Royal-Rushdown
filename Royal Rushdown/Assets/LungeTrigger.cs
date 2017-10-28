using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeTrigger : MonoBehaviour {

    public int nextNote;
    public List<GameObject> listo;
    public static bool correctInput = false;
    public static bool destroyNext = false;


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
            print(listo.Count);
            nextNote = listo[0].GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
            {
                correctInput = true;
                if (!TriggerZone.occupied)
                {
                    destroyNext = true;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) && nextNote == 1)
            {
                correctInput = true;
                if (!TriggerZone.occupieds
                {
                    destroyNext = true;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && nextNote == 2)
            {
                correctInput = true;
                if (!TriggerZone.occupied)
                {
                    destroyNext = true;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && nextNote == 3)
            {
                correctInput = true;
                if (!TriggerZone.occupied)
                {
                    destroyNext = true;
                }
            }

            if (correctInput && !TriggerZone.occupied)
            {
                GameController.globalSpeed = 10;
            }
            else
            {
                GameController.globalSpeed = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.Equals(null))
        {
            correctInput = false;
            listo.RemoveAt(0);
            GameController.globalSpeed = 1;
        }

    }

    // Update is called once per frame
    void Update() {
        if (listo.Count > 1) { }
        if (listo[0].gameObject.Equals(null))
        {
            listo.RemoveAt(0);
        }
    }
	
}
