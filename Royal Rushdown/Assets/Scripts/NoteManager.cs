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
    private void Awake()
    {
        noteList = new List<GameObject>();
    }
    void Start () {
        addNote(Direction.Right);
        addNote(Direction.Down);
        addNote(Direction.Left);
        addNote(Direction.Up);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
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
            Destroy(noteList[0]);
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
    
}
