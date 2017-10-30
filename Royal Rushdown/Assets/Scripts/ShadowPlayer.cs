using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlayer : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer targetRenderer;
    private SpriteRenderer myRenderer;
    private Animator myAnimator;
    private Animator targetAnimator;
	void Start () {
        targetRenderer = transform.parent.GetComponent<SpriteRenderer>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        targetAnimator = transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(targetAnimator.enabled == true)
        {
            myAnimator.enabled = true;
        } else
        {
            myAnimator.enabled = false;
            myRenderer.sprite = targetRenderer.sprite;
        }
        
	}
}
