using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public int nextNote;
    public List<GameObject> lister;

    // Use this for initialization
    void Start()
    {
        lister = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            lister.Add(other.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") == true)
        {
            print(lister.Count);
            nextNote = lister[0].GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKey(KeyCode.RightArrow) && nextNote == 1)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKey(KeyCode.DownArrow) && nextNote == 2)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && nextNote == 3)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }

            if (other.gameObject.GetComponent<NoteManager>().empty())
            {
                GameObject boneExplosion = (GameObject)Instantiate(Resources.Load("BoneExplosion"));
                boneExplosion.transform.position = lister[0].transform.position;
                Destroy(lister[0]);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.Equals(null))
        {
            Destroy(collision.gameObject);
            lister.RemoveAt(0);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
