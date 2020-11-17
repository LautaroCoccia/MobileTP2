using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLoggerEditor : SuperLogger
{
    const string PLUGIN_NAME = "com.coccialautaro.lclogger.LCSuperLogger";
    static AndroidJavaClass _pluginClass = null;
    static AndroidJavaObject _pluginInstance = null;

    static string path = Application.persistentDataPath;

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (_pluginClass == null)
            {
                _pluginClass = new AndroidJavaClass(PLUGIN_NAME);
            }
            return _pluginClass;
        }
    }

    public AndroidJavaObject PluginInstance
    {
        get
        {
            if (_pluginInstance == null)
            {
                _pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return _pluginInstance;
        }
    }
    public override void SendLog(string msj)
    {
        PluginInstance.Call("existearchivo", path);
        PluginInstance.Call("sendLog", msj);
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
