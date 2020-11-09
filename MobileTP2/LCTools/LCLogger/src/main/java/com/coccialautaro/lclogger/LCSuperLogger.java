package com.coccialautaro.lclogger;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

import java.util.ArrayList;

public class LCSuperLogger {
    private static final LCSuperLogger ourInstance = new LCSuperLogger();
    private static final String LOGTAG = "LCSuperLogger";
    private static final String GAMETAG = "TPNro2";

    //FILE CODE
    private static final String FILE_NAME = "log.txt";

    private static LCSuperLogger _instance =null;
    public static LCSuperLogger getInstance()
    {
        if(_instance ==null)
        {
            Log.d(LOGTAG, "LCSuperLogger created");
            _instance = new LCSuperLogger();
        }
        return _instance;
    }
    private ArrayList<String> allLogs = new ArrayList<String>();

    public void sendLog(String msj)
    {
        Log.d(GAMETAG, msj);
        allLogs.add(msj);

    }
    private static final String SEPARATOR = "\n";
    public String getAllLogs()
    {
        String logs = "";
        for (int i = 0; i< allLogs.size(); i++)
        {
            logs += allLogs.get(i) + SEPARATOR;
        }
        return logs;
    }

}

