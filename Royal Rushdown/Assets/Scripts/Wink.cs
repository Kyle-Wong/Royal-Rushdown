using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wink : MonoBehaviour {

    // Use this for initialization
    public Sprite defaultSprite;
    public Sprite activeSprite;
    public float duration;
    public float initialDelay;
	void Start () {
        StartCoroutine(winkAfterDelay());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator winkAfterDelay()
    {
        while (true)
        {
            GetComponent<Image>().sprite = defaultSprite;
            yield return new WaitForSeconds(initialDelay);
            GetComponent<Image>().sprite = activeSprite;
            yield return new WaitForSeconds(duration);
        }
    }
}
