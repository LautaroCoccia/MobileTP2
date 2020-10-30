using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager _instanceGameManager;

    private void Awake()
    {
        if(_instanceGameManager == null)
        {
            _instanceGameManager = this;
        }
        else if(_instanceGameManager != this )
        {
            Destroy(gameObject);
        }
    }

     public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void StartCorrutineLoadScene(string sceneTittle)
    {
        StartCoroutine(algo(sceneTittle));
    }
    IEnumerator algo(string name)
    {
        SceneManager.LoadSceneAsync(name);
        yield return new WaitForSecondsRealtime(1f);
    }

}


