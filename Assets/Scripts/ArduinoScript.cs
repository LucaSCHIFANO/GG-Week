using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

/* Not Working */
public class ArduinoScript : MonoBehaviour
{
    public SerialPort stream;
    public string dataString = null;
    public float dataGyroX;
    public float timerSet = 0.2f;
    private float timer;


    private void Awake()
    {
        //initialize stream open
        stream = new SerialPort("COM4", 9600);
        stream.ReadTimeout = 50;
        stream.Open();

        timer = timerSet;
    }

    private void Update()
    {
        //send message to arduino
        if (timer <= 0f)
        {
            //PING is asking arduino to give value in stream
            WriteToArduino("PING");
            ReadFromArduino();
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
        //stream.ReadTimeout = timeout;

        //StartCoroutine
        //(
        //    AsynchronousReadFromArduino
        //    (
        //        (string s) => Debug.Log(s),     // Callback
        //        () => Debug.LogError("Error!"), // Error callback
        //        10000f                          // Timeout (milliseconds)
        //    )
        //);

        //return dataString;

        
        try
        {
            dataString = stream.ReadLine();
            Debug.Log(dataString);
            //dataGyroX = float.Parse(stream.ReadLine());
            //Debug.Log(dataGyroX);

        }
        catch (TimeoutException e)
        {
            dataString = null;
            Debug.Log("Timeout");
        }
    }

    public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        dataString = null;

        do
        {
            try
            {
                dataString = stream.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                Debug.Log(dataString);
                yield break; // Terminates the Coroutine
            }
            else
            {
                Debug.Log("Wait for data");
                yield return null; // Wait for next frame
            }
                

            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        yield return null;
    }
}
