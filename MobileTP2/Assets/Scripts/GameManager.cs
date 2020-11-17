using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SuperLogger logger = SuperLogger.GetNewInstance();
    public static GameManager _instanceGameManager;

    private void Awake()
    {
        
        
        if (_instanceGameManager == null)
        {
            _instanceGameManager = this;
        }
        else if(_instanceGameManager != this )
        {
            Destroy(gameObject);
        }
    }
    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void StartCorrutineLoadScene(string sceneTittle)
    {
        StartCoroutine(Scene(sceneTittle));
    }
    IEnumerator Scene(string name)
    {
        string msj = "¿Permitir que Ball Rush acceda archivos de tu dispositivo?";
        logger.ShowAlertWindow(msj);
        logger.ExisteArchivo();
        logger.AsignarDatos("cargando Escena " + name);
        SceneManager.LoadSceneAsync(name);
        yield return new WaitForSecondsRealtime(1f);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}


