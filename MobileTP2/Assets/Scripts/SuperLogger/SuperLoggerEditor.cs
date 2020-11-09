using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLoggerEditor : SuperLogger
{
    public override void SendLog(string msj)
    {
        Debug.Log("Send log to Super logger: " + msj);
    }
    public override string GetAllLogs()
    {
        return "You are on Unity Editor";
    }
    public override void ShowAlertWindow(string msg)
    {
            Debug.LogWarning("AlertView not supported on this platform");   
    }
}
