﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI outputText= null;
    SuperLogger logger = null;
    private void Start()
    {
        logger = SuperLogger.GetNewInstance();
    }

    public void TutorialBtn()
    {
        logger.SendLog(Time.time.ToString());

        outputText.text = logger.GetAllLogs();
    }

    public void LogPermission()
    {
        string msj = "¿Permitir que TITULO DEL JUEGO acceda archivos de tu dispositivo?";
        logger.ShowAlertWindow(msj);
    }
    


}
