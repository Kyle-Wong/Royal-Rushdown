using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	float timer = 0f;
	float min = .5f;
	float range = 3f;
	float totalTime = 0;
	float spawnTime;
	public GameObject spawnPrefab;

    public float averageNotes = 1;              //1-6ish
    public float noteCountVariation = 0.33f;        //+-percent
    public float NoteVariety = 1;               //1-4

    public float averageNoteGrowth = 0.08f;
    public float noteVarietyGrowth = .12f;
	// Use this for initialization
	void Start () {
		spawnTime = min+range;
		StartCoroutine(decreaseRange());
	}

	void SpawnMe(){        
		GameObject newEnemy = (GameObject)Instantiate(spawnPrefab, transform.position, transform.rotation);
        int numNotes = (int)Mathf.Max(1,averageNotes*(1+-noteCountVariation + Random.value*noteCountVariation*2));
        int[] distinctNotesList = subList(new int[] { 0, 1, 2, 3 }, Mathf.Min(4,randFromAverage(NoteVariety)));
        for(int i = 0; i < numNotes; ++i)
        {
            newEnemy.GetComponent<NoteManager>().addNote(distinctNotesList[Random.Range(0, distinctNotesList.Length-1)]);
        }
    }
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= spawnTime) {
			SpawnMe();
			timer = 0f;
		}
		totalTime += Time.deltaTime;
	}

	IEnumerator decreaseRange()
	{
		while (range > 0) {
			range -= .2f;
			spawnTime = min + range;
            averageNotes += averageNoteGrowth;
            NoteVariety += noteVarietyGrowth;
			yield return new WaitForSeconds (3.33f);
		}
	}
    private int randFromAverage(float val)
    {
        int min = Mathf.FloorToInt(val);
        int max = Mathf.CeilToInt(val);
        return (Random.value > (val % 1)) ? min : max;
    }
    private int[] subList(int[] list, int newLength)
    {
        List<int> tempList = new List<int>(list);
        int[] result = new int[newLength];
        string toPrint = "newList";
        for(int i = 0; i < newLength; ++i)
        {
            int rng = Random.Range(0, tempList.Count);
            result[i] = tempList[rng];

            tempList.RemoveAt(rng);
            
            toPrint += ":" + result[i];
        }
        print(toPrint);
        return result;
    }
}
