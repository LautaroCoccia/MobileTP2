package com.coccialautaro.lclogger;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;
import android.view.WindowManager;

public class LCSuperLoggerPopUp {
    private static  final String TAG = "LCSuperLoggerPopUp";

    private LCSuperLoggerPopUp() {

    }

    public static LCSuperLoggerPopUp getInstance() {
        return SingletonHelper.INSTANCE;
    }
    public void ShowAlertWindow(Activity a, String msg){
        Log.i(TAG, "Showing alert ("+msg+")");

        AlertDialog d = new AlertDialog
                .Builder(a)
                .setTitle(msg)
                .setPositiveButton("PERMITIR", new DialogInterface.OnClickListener(){
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                })
                .setNegativeButton("RECHAZAR", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                })
                .create();
        d.setCancelable(false);
        d.setCanceledOnTouchOutside(false);
        d.getWindow()
                .setFlags(WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE, WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE);
        d.show();
    }
    private static class SingletonHelper {
        private static final LCSuperLoggerPopUp INSTANCE = new LCSuperLoggerPopUp();
    }
}
