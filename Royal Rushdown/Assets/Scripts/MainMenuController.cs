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
    public GameObject backButton;
    public UIRevealer[] nameList;
    public UIRevealer[] roleList;
    public GameObject credits;
    public float creditsInitialDelay = 0;
    public float creditsRepeatDelay = 0;
    private IEnumerator creditsReveal;
	void Start () {
        creditsReveal = revealCredits();
	}
    void Update()
    {
        switch (menuState)
        {
            case (MenuState.MainMenu):
                updateMainMenu();
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
    
    private IEnumerator revealCredits()
    {
        yield return new WaitForEndOfFrame();
        eventSystem.SetSelectedGameObject(backButton);

        
        yield return new WaitForSeconds(creditsInitialDelay);
        for(int i = 0; i < nameList.Length; i++)
        {
            nameList[i].revealUI();
            roleList[i].revealUI();
            yield return new WaitForSeconds(creditsRepeatDelay);
        }
    }
	// Update is called once per frame
	
    public void playButtonPress()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    public void creditsButtonPress()
    {
        credits.SetActive(true);

        
        creditsReveal = revealCredits();
        StartCoroutine(creditsReveal);
    }
    public void quitButtonPress()
    {
        Application.Quit();
    }
    public void backButtonPress()
    {
        StopCoroutine(creditsReveal);

        eventSystem.SetSelectedGameObject(playButton);
        for (int i = 0; i < nameList.Length; i++)
        {
            nameList[i].hideImmediately();
            roleList[i].hideImmediately();
        }
        credits.SetActive(false);
    }
}
