using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAllSounds : MonoBehaviour {

    // Use this for initialization
    public AudioClip[] clipList;
    private AudioSource source;
	void Start () {
        source = GetComponent<AudioSource>();
		for(int i = 0; i < clipList.Length; ++i)
        {
            playClip(clipList[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void playClip(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    
}
