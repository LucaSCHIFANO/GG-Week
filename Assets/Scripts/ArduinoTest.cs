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
    public float bpm = 1;

    private bool hasSendMessage = false;
    public bool hasStreamOpen = false;

    private bool isBeating = false;
    private void Awake()
    {
        int i = 0;
        //initialize stream open
        while (!hasStreamOpen)
        {

            
            stream = new SerialPort(GetStreamPort(i), 9600);
            stream.ReadTimeout = 50;
            try
            {
                stream.Open();
                hasStreamOpen = true;
            }
            catch
            {
                GameEvents.hasNotArduino.Invoke();
                hasStreamOpen = false;
                i++;
                Debug.Log("Stream not found");

            }
        }

        //initialize stream open
        //stream = new SerialPort("COM3", 9600);
        //stream.ReadTimeout = 50;
        //try
        //{
        //    stream.Open();
        //    hasStreamOpen = true;
        //}
        //catch
        //{
        //    GameEvents.hasNotArduino.Invoke();
        //    hasStreamOpen = false;
        //    Debug.Log("Stream not found");
        //}

    }
    private string GetStreamPort(int i)
    {
        string portname = "COM" + i.ToString();

        return portname;
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

        Debug.Log(isBeating + "Before");
        if (!isBeating)
        {
            StartCoroutine(Hearbeat());
            Debug.Log(isBeating + "After");
        }

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
        catch (TimeoutException e)
        {
            dataString = null;
            //Debug.Log("Timeout");
        }
    }

    IEnumerator Hearbeat()
    {
        isBeating = true;
        float timeOn = 1f;
        while(timeOn > 0)
        {
            WriteToArduino("VibratorOn");
            timeOn -= Time.deltaTime;
            Debug.Log("VibratorOn");
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(0.2f);
        float timeOff = 1f;
        while (timeOff > 0)
        {
            WriteToArduino("VibratorOff");
            timeOff -= Time.deltaTime;
            Debug.Log("Vibrator Off");
            yield return new WaitForEndOfFrame();
        }

        //yield return new WaitForSeconds(bpm);
        isBeating = false;
    }
}
