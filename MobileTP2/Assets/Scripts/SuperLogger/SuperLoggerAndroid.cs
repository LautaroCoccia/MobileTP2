﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLoggerAndroid : SuperLogger
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

    public override void ExisteArchivo()
    {
        PluginInstance.Call("existearchivo", path);
    }
    public override void AsignarDatos(string msg)
    {
        PluginInstance.Call("asignardatos", msg);
    }

    public override void MostrarArchivos()
    {
        PluginInstance.Call("mostrararchivos", path);

    }

    public override void ShowAlertWindow(string msg)
    {
        using (var playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            using (var pluginClass = new AndroidJavaClass("com.coccialautaro.lclogger.LCSuperLoggerPopUp")) 
            {
                pluginClass.CallStatic<AndroidJavaObject>("getInstance")
                    .Call("ShowAlertWindow", new object[] { activity, msg });
            }
        }
        Debug.Log("SuperLoggerPopUp.string msg(" + msg + ")");

    }
    
}

