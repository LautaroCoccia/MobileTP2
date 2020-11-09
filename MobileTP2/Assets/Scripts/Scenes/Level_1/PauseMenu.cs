using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuIU;
    
    public void Resume()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
