using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class LevelManager : MonoBehaviour
{
    public GameObject Player;
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
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
