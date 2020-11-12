using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LevelManager : MonoBehaviour
{
    public GameObject Background;
    public GameObject PauseMenu;
    public GameObject QuitOption;
    public GameObject QutToMenu;
    public GameObject RestartOption;
    public GameObject GameOverScreen;
    public GameObject FinishScreen;

    
   
    enum GameState
    {
        Play,
        Pause,
        Win,
        Lose
    }
    GameState gameState = GameState.Play;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && (gameState != GameState.Lose || gameState != GameState.Win))
        {
            if (gameState == GameState.Pause)
            {
                Resume();
            }
            else if(gameState == GameState.Play)
            {
                Pause();
            }
        }
        else if(gameState == GameState.Lose)
        {
            Lose();
        }
        else if(gameState == GameState.Win)
        {
            Win();
        }
       
    }
    public void Resume()
    {
        gameState = GameState.Play;
        Background.SetActive(false);
        PauseMenu.SetActive(false);
        QuitOption.SetActive(false);
        QutToMenu.SetActive(false);
        RestartOption.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        gameState = GameState.Pause;
        Background.SetActive(true);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        Background.SetActive(true);
        PauseMenu.SetActive(false);
        FinishScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Lose()
    {
        Background.SetActive(true);
        PauseMenu.SetActive(false);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
   

}
