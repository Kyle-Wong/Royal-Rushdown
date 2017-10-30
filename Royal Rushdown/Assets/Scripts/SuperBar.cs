using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuperBar : MonoBehaviour {

    // Use this for initialization
    private RectTransform insideBar;
    private Image insideImage;
    private Text spaceText;
    
	void Start () {
        insideBar = transform.GetChild(1).GetComponent<RectTransform>();
        insideImage = transform.GetChild(1).GetComponent<Image>();
        spaceText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        spaceText.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.gameState == GameController.GameState.InGame)
        {
            insideBar.anchorMax = new Vector2(Mathf.Clamp(AttackZone.superCharge * 1f / 100, 0, 1), 1);
            if(AttackZone.superCharge <= 99)
            {
                spaceText.enabled = false;
                insideImage.color = new Color(1, 1, .29f, 1);
            } else if(AttackZone.superCharge >= 100)
            {
                spaceText.enabled = true;
                insideImage.color = Color.red;
                insideImage.color = new Color(1, .196f, .196f, 1);
            }
        }
	}
}
