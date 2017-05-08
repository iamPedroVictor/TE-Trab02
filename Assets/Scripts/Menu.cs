using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MenuStatus
{
    Main,
    Credits
}

public class Menu : MonoBehaviour {

    public MenuStatus menuStatus;

    public GameObject MainMenuPanel, CreditsPanel;

    public Image playImage, creditsImage;

    public bool isPlayButton;

    public float timeToFreeze;
    private float timeInFreeze = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        menuStatus = MenuStatus.Main;
        isPlayButton = true;
        SwithMenu(menuStatus);
        
    }

    private void Update()
    {
        if(menuStatus == MenuStatus.Main)
        {
            MainMenu();
        }
        else if(menuStatus == MenuStatus.Credits)
        {
            CredistMenu();
        }
        
    }

    public void MainMenu()
    {
        if(Input.GetAxis("JoystickV1") != 0 && timeInFreeze < Time.timeSinceLevelLoad)
        {
            if (isPlayButton){
                ButtonSwith(true);
            }else{
                ButtonSwith(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button0)){
            if (isPlayButton){
                GoPlay();
            }else{
                SwithMenu(MenuStatus.Credits);
            }
        }

    }

    public void CredistMenu(){
        if (Input.anyKeyDown){
            SwithMenu(MenuStatus.Main);
        }
    }

    public void ButtonSwith(bool isPlay)
    {
        if (isPlay){
            playImage.color = Color.white;
            creditsImage.color = Color.red;
        }else{
            playImage.color = Color.red;
            creditsImage.color = Color.white;
        }
        isPlayButton = !isPlay;
        timeInFreeze = Time.timeSinceLevelLoad + timeToFreeze;
    }

    public void SwithMenu(MenuStatus newStatus)
    {
        if(newStatus == MenuStatus.Main)
        {
            MainMenuPanel.SetActive(true);
            CreditsPanel.SetActive(false);
        }else if(newStatus == MenuStatus.Credits){
            MainMenuPanel.SetActive(false);
            CreditsPanel.SetActive(true);
        }
        menuStatus = newStatus;
    }

    private void GoPlay()
    {
        SceneManager.LoadScene("Play");
    }

}
