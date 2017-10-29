using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

    // Use this for initialization
    public PlayerEnemyInteraction player;
    private RectTransform insideTransform;
    private Image myImage;
    private Image childImage;
	void Start () {
        insideTransform = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        myImage = GetComponent<Image>();
        childImage = transform.GetChild(0).gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

		if(GameController.gameState == GameController.GameState.InGame && Mathf.InverseLerp(0,100,player.health) >= .99f)
        {
            myImage.enabled = false;
            childImage.enabled = false;
        } else
        {
            myImage.enabled = true;
            childImage.enabled = true;
        }
        insideTransform.anchorMax = new Vector2(Mathf.Clamp(Mathf.InverseLerp(0,100,player.health),0,1),1);
	}
}
