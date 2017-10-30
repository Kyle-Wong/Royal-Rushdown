using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization
    public static float globalSpeed;
    public static float defaultSpeed;
    public static float maxSpeed;
    public enum GameState
    {
        PreGame, InGame, PostGame
    }
   
    public static GameState gameState;
    public EventSystem eventSystem;
    
    public GameObject restartButton;
    private Text restartText;
    public GameObject mainMenuButton;
    private Text mainMenuText;
    public Font defaultFont;
    public Font activeFont;
    private GameObject[] deathScreenUI;
    public GraphicColorLerp blackOverlay;
    private void Awake()
    {
        globalSpeed = 1f;
        defaultSpeed = 1f;
        maxSpeed = 2.5f;
        gameState = GameState.InGame;
    }
    void Start () {
        restartText = restartButton.transform.parent.GetComponent<Text>();
        mainMenuText = mainMenuButton.transform.parent.GetComponent<Text>();
        deathScreenUI = GameObject.FindGameObjectsWithTag("DeathScreenUI");
        
	}
	
	// Update is called once per frame
	void Update () {

        if (globalSpeed < 1)
        {
            globalSpeed += .1f;
        }

        if(defaultSpeed < 1)
        {
            defaultSpeed += .1f;
        }

        switch (gameState)
        {
            case (GameState.PreGame):
                break;
            case (GameState.InGame):
                break;
            case (GameState.PostGame):
                updateDeathScreen();
                break;
        }
	}
    public void revealDeathScreen()
    {
        eventSystem.SetSelectedGameObject(restartButton);
        for(int i = 0; i < deathScreenUI.Length; ++i)
        {
            deathScreenUI[i].GetComponent<GraphicColorLerp>().startColorChange();
        }
    }
    public void updateDeathScreen()
    {
        if(eventSystem.currentSelectedGameObject == restartButton)
        {
            restartText.font = activeFont; 
        } else
        {
            restartText.font = defaultFont;
        }
        if(eventSystem.currentSelectedGameObject == mainMenuButton)
        {
            mainMenuText.font = activeFont;
        } else
        {
            mainMenuText.font = defaultFont;
        }
    }
    public void restartButtonPress()
    {
        blackOverlay.startColor = new Color(0, 0, 0, 0);
        blackOverlay.endColor = new Color(0, 0, 0, 1);
        blackOverlay.startColorChange();
        StartCoroutine(loadAfterDelay(blackOverlay.duration, "GameplayScene"));
    }
    public void mainMenuButtonPress()
    {
        blackOverlay.startColor = new Color(0, 0, 0, 0);
        blackOverlay.endColor = new Color(0, 0, 0, 1);
        blackOverlay.startColorChange();
        StartCoroutine(loadAfterDelay(blackOverlay.duration, "MainMenu"));
    }
    public int getGameState()
    {
        return (int)gameState;
    }
    public void setGameState(int state)
    {
        gameState = (GameState)state;
        switch ((GameState)state)
        {
            case (GameState.PreGame):
                break;
            case (GameState.InGame):
                break;
            case (GameState.PostGame):
                revealDeathScreen();
                break;
        }
    }
    private IEnumerator loadAfterDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
