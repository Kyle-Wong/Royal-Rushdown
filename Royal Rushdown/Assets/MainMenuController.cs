using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour {

    // Use this for initialization
    public enum MenuState
    {
        MainMenu, Credits
    }
    public MenuState menuState = MenuState.MainMenu;
    public EventSystem eventSystem;
    public GameObject playButton;
    public GameObject creditsButton;
    public GameObject quitButton;

	void Start () {
        
	}
    void Update()
    {
        switch (menuState)
        {
            case (MenuState.MainMenu):
                updateMainMenu();
                break;
            case (MenuState.Credits):
                updateCredits();
                break;
        }
    }
    private void updateMainMenu()
    {
        //if (eventSystem.currentSelectedGameObject == playButton)
        //{
        //} else
        //{
        //}
        //if (eventSystem.currentSelectedGameObject == creditsButton)
        //{
        //}
        //else
        //{
        //}
        //if (eventSystem.currentSelectedGameObject == quitButton)
        //{
        //}
        //else
        //{
        //}
    }
    private void updateCredits()
    {

    }
	// Update is called once per frame
	
    public void playButtonPress()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void creditsButtonPress()
    {
        
    }
    public void quitButtonPress()
    {
        Application.Quit();
    }
}
