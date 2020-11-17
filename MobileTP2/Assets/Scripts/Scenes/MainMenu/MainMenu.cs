using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI outputText;
    SuperLogger logger = null;
    private void Start()
    {
        logger = SuperLogger.GetNewInstance();
    }


    public void LogPermission()
    {
        string msj = "¿Permitir que Ball Rush acceda archivos de tu dispositivo?";
        logger.ShowAlertWindow(msj);
        logger.ExisteArchivo();
        logger.AsignarDatos("deja de tocarme");
    }
    


}
