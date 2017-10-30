using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

    // Use this for initialization
    public string[] wordList;
    public bool useRandom = true;
    private TextMesh myText;
	void Start () {
        myText = GetComponent<TextMesh>();
        if (useRandom)
        {
            myText.text = wordList[Random.Range(0, wordList.Length)];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
