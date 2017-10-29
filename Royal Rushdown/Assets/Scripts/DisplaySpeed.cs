using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplaySpeed : MonoBehaviour {

    // Use this for initialization
    public Image[] chevronList;
    private float startingSpeed;
	void Start () {
        startingSpeed = GameController.defaultSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameState == GameController.GameState.InGame)
        {
            float percent = Mathf.InverseLerp(startingSpeed, GameController.maxSpeed, GameController.defaultSpeed);
            if ( percent < 0.33f)
            {
                chevronList[0].enabled = true;
                chevronList[1].enabled = false;
                chevronList[2].enabled = false;
                chevronList[0].color = new Color(.29f, 1, .29f, 1);
            } else if(percent < 0.66f)
            {
                chevronList[0].enabled = true;
                chevronList[1].enabled = true;
                chevronList[2].enabled = false;
                chevronList[0].color = new Color(.29f, 1, .29f, 1);
                chevronList[1].color = new Color(1, 1, .29f, 1);


            }
            else if (percent < 0.95f)
            {
                chevronList[0].enabled = true;
                chevronList[1].enabled = true;
                chevronList[2].enabled = true;
                chevronList[0].color = new Color(.29f, 1, .29f, 1);
                chevronList[1].color = new Color(1, 1, .29f, 1);
                chevronList[2].color = new Color(1, .196f, .196f, 1);
            } else
            {
                chevronList[0].enabled = true;
                chevronList[1].enabled = true;
                chevronList[2].enabled = true;
                chevronList[0].color = new Color(1, .196f, .196f, 1);
                chevronList[1].color = new Color(1, .196f, .196f, 1);
                chevronList[2].color = new Color(1, .196f, .196f, 1);
            }
        }
	}
}
