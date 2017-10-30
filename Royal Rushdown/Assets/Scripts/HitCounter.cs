using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour {

    // Use this for initialization
    public Color startColor;
    public Color endColor;
    public int endColorShiftAt = 100;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = AttackZone.combo + "x";
        if(AttackZone.combo%10 == 0)
            GetComponent<Text>().color = Color.Lerp(startColor, endColor, FightZone.hitCounter*1f / endColorShiftAt);
    }
}
