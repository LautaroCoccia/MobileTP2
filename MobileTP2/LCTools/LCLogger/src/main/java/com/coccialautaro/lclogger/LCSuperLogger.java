package com.coccialautaro.lclogger;

import android.app.Activity;
import android.util.Log;


import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.Scanner;

public class LCSuperLogger {
    Scanner entrada;
    String user;
    float posX;
    private static final LCSuperLogger ourInstance = new LCSuperLogger();
    private static final String LOGTAG = "SuperLogger";
    private static final String GAMETAG = "TPNro2";
    private static final String MyFile = "Logs.txt";
    File ficherodeposito;
    private static LCSuperLogger _instance =null;
    public static LCSuperLogger getInstance()
    {
        if(_instance ==null)
        {

            Log.d(LOGTAG, "SuperLogger created");
            _instance = new LCSuperLogger();
        }
        return _instance;
    }
    public void existearchivo(String Mypath){
        ficherodeposito = new File(Mypath + MyFile);
        try{
            if (ficherodeposito.exists()) {
                Log.d(LOGTAG,"ya existe");
                Log.i("Try: ", "YA EXISTO");
            }
            else{

                ficherodeposito.createNewFile();
                Log.d(LOGTAG,"creado");
                Log.d(LOGTAG,Mypath);
                Log.i("Try: ", "NO EXISTO");
            }
        }
        catch(Exception ex)
        {
            Log.e(ex.getMessage(),"Error");
        }

    }

    public void asignardatos(String name, float dato){
        user = name;
        posX = dato;
        try{
            BufferedWriter Fescribe=new BufferedWriter( new OutputStreamWriter(new FileOutputStream(ficherodeposito,true)));
            Fescribe.write(name+"   "+ dato + "     " );
            Fescribe.write("\n");
            Log.d(name,"posX " + dato);
            Fescribe.close();
        }
        catch(Exception ex) {
            Log.e("ERROR: ",ex.getMessage());
        }
    }
    public void mostrararchivos(String Mypath){
        try{
            FileReader fr= new FileReader(Mypath + MyFile);
            BufferedReader br= new BufferedReader(fr);
            String cadena;
            while((cadena=br.readLine())!=null){
                Log.d("", cadena);
            }
        }
        catch(Exception ex){
            Log.e("ERROR: ",ex.getMessage());
        }
    }
    public String buscarregistro(String name)
    {
        String usuario = name;
        try{
            BufferedReader read= new BufferedReader(new FileReader("deposito.txt"));
            String linea = "";
            while((linea=read.readLine())!= null){
                if(linea.indexOf(usuario)!=-1){
                    Log.d("se encontro el regis: ", linea);
                    String algo = linea
                }
            }
        }
        catch (Exception  ex){
            Log.e("ERROR: ", ex.getMessage());
        }
    }
    public void saldoderegistro(String name){
        user = name;
        try{
            entrada = new Scanner(new File ("deposito.txt"));
            BufferedReader read= new BufferedReader(new FileReader("deposito.txt"));
            String linea = "";
            while((linea = read.readLine())!=null){
                if(linea.indexOf(user)!= -1)
                {
                    Log.d("se encontro el user: ", user);
                    float pos=entrada.nextFloat();
                    Log.d("POSICION","pos: " + pos);
                }
            }
        }
        catch(Exception ex){
            Log.e("ERROR: ",ex.getMessage());
        }
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
