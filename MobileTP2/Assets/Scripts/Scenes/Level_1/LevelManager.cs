using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LevelManager : MonoBehaviour
{
    public GameObject Backgrpund;
    public GameObject PauseMenu;
    public GameObject QuitOption;
    public GameObject QutToMenu;
    public GameObject RestartOption;
    public GameObject Player;
    public GameObject GameOverScreen;
    public GameObject FinishScreen;
    private static bool pause = false;

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
       
    }
    public void Resume()
    {
        Backgrpund.SetActive(false);
        PauseMenu.SetActive(false);
        QuitOption.SetActive(false);
        QutToMenu.SetActive(false);
        RestartOption.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    public void Pause()
    {
        Backgrpund.SetActive(true);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
             
        }
        if (collision.transform.tag == "Checker")
        {
        }
        if (collision.transform.tag == "FinishLine")
        {
            Time.timeScale = 0;
        }
    }
    

}
