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
    private GameObject selectedButton;
    public AudioClip buttonSelectSound;
    private IEnumerator creditsReveal;
    public GraphicColorLerp blackOverlay;
	void Start () {
        creditsReveal = revealCredits();
        selectedButton = eventSystem.currentSelectedGameObject;
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
        if(selectedButton != eventSystem.currentSelectedGameObject && !Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().PlayOneShot(buttonSelectSound);
        }
        selectedButton = eventSystem.currentSelectedGameObject;
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
        eventSystem.SetSelectedGameObject(null);
        blackOverlay.startColor = new Color(0, 0, 0, 0);
        blackOverlay.endColor = new Color(0, 0, 0, 1);
        blackOverlay.startColorChange();
        StartCoroutine(loadAfterTime(blackOverlay.duration));
    }
    public void creditsButtonPress()
    {
        credits.SetActive(true);

        
        creditsReveal = revealCredits();
        StartCoroutine(creditsReveal);
        menuState = MenuState.Credits;
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
        menuState = MenuState.MainMenu;
    }
    private IEnumerator loadAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameplayScene");
    }
}
