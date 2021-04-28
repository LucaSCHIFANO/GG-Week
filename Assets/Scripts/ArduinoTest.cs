using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

/* Working Arduino Code */
public class ArduinoTest : MonoBehaviour
{
    public SerialPort stream;
    public string dataString = null;
    public float timerSet;
    private float timer;

    private bool hasSendMessage = false;
    public bool hasStreamOpen = false;

    private string GetStream(int index)
    {
        return "COM" + index.ToString();
    }
    private void Awake()
    {
        int i = 0;
        while(i <= 10)
        {

            i++;
            stream = new SerialPort(GetStream(i), 9600);
            stream.ReadTimeout = 50;

            try
            {
                stream.Open();
                hasStreamOpen = true;
            }
            catch
            {
                hasStreamOpen = false;   
            }
        }

        if (!hasStreamOpen)
        {
            Debug.Log("Stream not found");
            GameEvents.hasNotArduino.Invoke();
        }
    }

    private void Update()
    {
        if(!hasStreamOpen) { return; }
        //send message to arduino
        if (!hasSendMessage)
        {
            //Ask arduino to send data
            WriteToArduino("AskData");
            hasSendMessage = true;
            ReadFromArduino();
        }

        //wait before asking data again (anti lag)
        if (timer <= 0)
        {
            hasSendMessage = false;
            timer = timerSet;
        }
        timer -= Time.deltaTime;

    }

    public void WriteToArduino(string message)
    {
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }

    public void ReadFromArduino()
    {
        try
        {
            dataString = stream.ReadLine();
            //Debug.Log(dataString);
        }
        catch (TimeoutException)
        {
            dataString = null;
            //Debug.Log("Timeout");
        }
    }
}
