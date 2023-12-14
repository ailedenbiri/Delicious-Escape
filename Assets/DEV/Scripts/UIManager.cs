using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] TMP_Text text;
    [SerializeField] float time;

    [Header("MainMenu")]
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject quitGameButton;


    [Header("PausePanel")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject playButton;
 


    [Header("Settings")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject soundOnButton;
    [SerializeField] private GameObject soundOffButton;



    [Header("GameOver")]
    [SerializeField] private GameObject endGamePanel;







 
    private bool isCountdown = false;


   
    //GAME TIMER
    private void Update()
    {    
        time = isCountdown ? time -= Time.deltaTime : time += Time.deltaTime;
        SetTimerText();     
    }

    private void SetTimerText()
    {
        text.text = time.ToString("0.00");
    }





    //MAIN MENU PANELS

    public void PlayGame()
    {
        SceneManager.LoadScene("GAME");
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }



    //GAME PANELS

    public void Pause()
    {
        pausePanel.SetActive(true);      
        pauseButton.SetActive(false);
        playButton.SetActive(true);
       
        Time.timeScale = 0f;

    }

    public void Continue()
    {
        
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(false);
        Time.timeScale = 1f;


    }

    public void SettingsInGame()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        Time.timeScale = 0f;

        soundOnButton.SetActive(true);
        soundOffButton.SetActive(true);
    }

  

    //SETTINGS PANEL

    public void Settings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        soundOnButton.SetActive(true);
        soundOffButton.SetActive(true);
        quitButton.SetActive(true);

    }

    public void QuitButton()
    {
        quitButton.SetActive(true);
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }

  
    public void RestartGame()
    {
        SceneManager.LoadScene("GAME");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndGame");
        restartButton.SetActive(true);
        quitButton.SetActive(true);
    }


}
