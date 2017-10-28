using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour {

	// Use this for initialization
    public enum Direction
    {
        Up, Right, Down, Left
    }
    public List<GameObject> noteList;
    public string prefabName;
    public float listOffset;
    public float noteOffset;
    public bool debug = false;
    private void Awake()
    {
        noteList = new List<GameObject>();
        if (debug)
        {
            addNote(Direction.Right);
            addNote(Direction.Down);
            addNote(Direction.Left);
            addNote(Direction.Up);
        }
    }
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        if (debug && Input.GetKeyDown(KeyCode.Space))
        {
            printNotes();
            removeFront();
            printNotes();
        }
	}
    
    public void addNote(int dir)
    {
        GameObject newNote = (GameObject)Instantiate(Resources.Load(prefabName));
        newNote.GetComponent<DirectionalNote>().followEnemy(gameObject.transform,listOffset+noteOffset*noteList.Count);
        newNote.GetComponent<DirectionalNote>().setDirection(dir);
        noteList.Add(newNote);
    }
    public void addNote(Direction dir)
    {
        GameObject newNote = (GameObject)Instantiate(Resources.Load(prefabName));
        newNote.GetComponent<DirectionalNote>().followEnemy(gameObject.transform, listOffset + noteOffset * noteList.Count);
        newNote.GetComponent<DirectionalNote>().setDirection((int)dir);
        noteList.Add(newNote);
    }
    public int removeFront()
    {
        if (!empty())
        {
            
            int toReturn = getNextNoteDirection();
            noteList[0].GetComponent<ColorLerp>().startColorChange();
            Destroy(noteList[0],.6f);
            noteList.RemoveAt(0);
            for (int i = 0; i < noteList.Count; i++)
            {
                noteList[i].GetComponent<DirectionalNote>().updateOffset(listOffset + noteOffset * i);
            }
            
            return toReturn;
        }
        else
        {
            return -1;      //empty list
        }
    }
    public int noteListSize()
    {
        return noteList.Count;
    }
    public bool empty()
    {
        return noteList.Count == 0;
    }
    public int getNextNoteDirection()
    {
        if (!empty())
        {
            return (int)noteList[0].GetComponent<DirectionalNote>().getDirection();
        } else
        {
            return -1;      //empty list
        }
    }
    public void printNotes()
    {
        string result = "next->";
        for(int i = 0; i < noteList.Count; i++)
        {
            result+=((Direction)noteList[i].GetComponent<DirectionalNote>().getDirection()) + "->";
        }
        result += "end";
        print(result);
    }
    public void flashColor(Color initialColor, Color endColor, float duration, float initialDelay)
    {
        if (!empty())
        {
            noteList[0].GetComponent<ColorLerp>().setColors(initialColor, endColor);
            noteList[0].GetComponent<ColorLerp>().initialDelay = initialDelay;
            noteList[0].GetComponent<ColorLerp>().duration = duration;
            noteList[0].GetComponent<ColorLerp>().startColorChange();
        } else
        {
            print("NO NOTES TO BE FOUND HERE");
        }
    }
}
