using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    public static float timer = 0;
    public int nextNote;
    public List<GameObject> lister;
    public static bool occupied = false;
    public static bool hitReady;

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
        print(timer);
        print(hitReady);
        timer = timer + Time.deltaTime;

        if (timer > 1)
        {
            hitReady = true;
            timer = 0;
        }
        if (lister.Count > 0)
        {
            print(lister.Count);
            nextNote = lister[0].GetComponent<NoteManager>().getNextNoteDirection();
            if (Input.GetKeyDown(KeyCode.UpArrow) && nextNote == 0 && hitReady)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
                hitReady = false;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && nextNote == 1 && hitReady)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
                hitReady = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && nextNote == 2 && hitReady)
            {
                lister[0].GetComponent<ColorLerp>().startColorChange();
                lister[0].GetComponent<NoteManager>().removeFront();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && nextNote == 3 && hitReady)
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
