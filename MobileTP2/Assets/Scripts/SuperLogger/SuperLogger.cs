using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SuperLogger
{
    public static SuperLogger GetNewInstance()
    {
#if UNITY_EDITOR
        return new SuperLoggerEditor();
#elif UNITY_ANDROID
        return new SuperLoggerAndroid();
#endif
    }

    public abstract void SendLog(string msj);
    public abstract string GetAllLogs();
    public abstract void ShowAlertWindow(string msg);
}
