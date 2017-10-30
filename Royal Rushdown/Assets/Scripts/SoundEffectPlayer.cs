using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{

    // Use this for initialization
    public AudioClip[] clips;
    private AudioSource source;
    public bool allowRepeats = false;
    private int lastPlayed = 0;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void playRandomSound()
    {
        int index = 0;
        while (clips.Length > 1)
        {
            index = Random.Range(0, clips.Length);
            if (allowRepeats || index != lastPlayed)
                break;
        }
        lastPlayed = index;
        source.PlayOneShot(clips[index]);
    }
    public void playSound(int clipNum)
    {
        lastPlayed = clipNum;
        source.PlayOneShot(clips[clipNum]);
    }
}
