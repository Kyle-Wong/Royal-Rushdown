using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{

    public int nextNote;
    public List<GameObject> lister;
    public static bool occupied = false;

    // Use this for initialization
    void Start()
    {
        lister = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        occupied = true;
        if (other.gameObject.CompareTag("Enemy") == true)
        {
            lister.Add(other.gameObject);
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
            Destroy(collision.gameObject);
            lister.RemoveAt(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (lister.Count > 0)
        {
            print(lister.Count);
            nextNote = lister[0].GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextNote == 1)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextNote == 2)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextNote == 3)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (LungeTrigger.destroyNext)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
                LungeTrigger.destroyNext = false;
            }
            if (lister[0].gameObject.GetComponent<NoteManager>().empty())
            {
                GameObject boneExplosion = (GameObject)Instantiate(Resources.Load("BoneExplosion"));
                boneExplosion.transform.position = lister[0].transform.position;
                boneExplosion.GetComponent<ParticleExplosion>().explode(15, 2);
                Destroy(lister[0]);
            }
        }
    }
}
