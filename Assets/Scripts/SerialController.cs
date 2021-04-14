using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialController : MonoBehaviour
{
    public Controller controller;
    public WineSimulation glass;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;
    
    [Header("Debug")]
    public Vector2 position;
    //public string vectString;
    //public string accelX;
    //public string accelY;

    private bool hasValue = false;
    ArduinoTest arduino;

    private void Start()
    {
        arduino = GetComponent<ArduinoTest>();
    }
    // Update is called once per frame
    void Update()
    {
        if(arduino.hasStreamOpen == false) { return; }
        GetPositionValue();
        if(position.x > maxX)
        {
            controller.FillUpSelection();
            glass.MoveUp();
            controller.flowchart.SetStringVariable("Direction", "Up");
            Debug.Log("Forward");
        }else if(position.x < minX)
        {
            controller.FillUpSelection();
            glass.MoveDown();
            controller.flowchart.SetStringVariable("Direction", "Down");
            Debug.Log("Back");
        }else if(position.y > maxY)
        {
            controller.FillUpSelection();
            glass.MoveLeft();
            controller.flowchart.SetStringVariable("Direction", "Left");
            Debug.Log("Left");
        }else if(position.y < minY)
        {
            controller.FillUpSelection();
            glass.MoveRight();
            controller.flowchart.SetStringVariable("Direction", "Right");
            Debug.Log("Right");
        }
        else
        {
            controller.FillDownSelection();
            glass.ResetPosition();
            controller.flowchart.SetStringVariable("Direction", "None");
        }
        
    }

    private void GetPositionValue()
    {
        if (arduino.dataString != null)
        {
            string[] values = arduino.dataString.Split(',');
            int i = 0;
            foreach (string value in values)
            {
                if (value != "")
                {
                    if (i == 0)
                    {
                        position.x = float.Parse(value);
                    }
                    else if (i == 1)
                    {
                        position.y = float.Parse(value);
                    }

                    hasValue = true;
                }
                i++;
            }
            //vectString = arduino.dataString;
            //int separation = vectString.IndexOf(",");
            //string tmp = vectString;
            //string tmp2 = vectString;
            //if (separation > 0)
            //{
            //    accelX = tmp.Substring(0, separation);
            //    accelY = tmp2.Substring(separation + 1, tmp2.Length - separation - 1);
            //    vect.x = int.Parse(accelX);
            //    vect.y = int.Parse(accelY);
            //}
        }
    }
}
