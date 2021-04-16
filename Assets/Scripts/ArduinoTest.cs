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
        //initialize stream open
        stream = new SerialPort("COM5", 9600);
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
            Debug.Log("Stream not found");

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

        if (!isBeating)
        {
            StartCoroutine(Hearbeat());
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
        WriteToArduino("VibratorOn");
        isBeating = true;
        yield return new WaitForSeconds(0.2f);
        
        float timeBeat = 0.5f;
        while (timeBeat > 0)
        {
            WriteToArduino("VibratorOff");
            timeBeat -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Vibrator Off");
        yield return new WaitForSeconds(bpm);
        isBeating = false;
    }
}
