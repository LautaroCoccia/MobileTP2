using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLoggerEditor : SuperLogger
{
   
    
    public override void ShowAlertWindow(string msg)
    {
        Debug.LogWarning("AlertView not supported on this platform");   
    }
    public override void ExisteArchivo()
    {
        Debug.LogWarning("AlertView not supported on this platform");
    }
    public override void AsignarDatos(string msg)
    {
        Debug.LogWarning("AlertView not supported on this platform");
    }

    public override void MostrarArchivos()
    {
        Debug.LogWarning("AlertView not supported on this platform");
    }
}
