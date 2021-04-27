using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    ControllerUI controllerUI;
    WineSimulation glass;
    ArduinoTest arduino;

    private bool controllerIsActive = false;

    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;

    [Header("Debug")]
    public Vector2 position;
    public string vectString;
    public string accelX;
    public string accelY;


    private bool hasValue = false;

    public static ControllerManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            controllerUI = FindObjectOfType<ControllerUI>();
            glass = FindObjectOfType<WineSimulation>();
            arduino = FindObjectOfType<ArduinoTest>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if(arduino.hasStreamOpen)
        {
            GetPositionValue();
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        //up
        if (verticalInput > 0 || position.x > maxX)
        {
            controllerUI.FillUpSelection();
            controllerUI.ChangeSprite(ControllerPosition.Up, ControllerType.Keyboard);
            controllerUI.flowchart.SetStringVariable("Direction", "Up");
            glass.MoveUp();
        }//down
        else if (verticalInput < 0 || position.x < minX)
        {
            controllerUI.FillUpSelection();
            controllerUI.ChangeSprite(ControllerPosition.Down, ControllerType.Keyboard);
            controllerUI.flowchart.SetStringVariable("Direction", "Down");
            glass.MoveDown();
        }//right
        else if (horizontalInput > 0 || position.y > maxY)
        {
            controllerUI.FillUpSelection();
            controllerUI.ChangeSprite(ControllerPosition.Right, ControllerType.Keyboard);
            controllerUI.flowchart.SetStringVariable("Direction", "Right");
            glass.MoveRight();
        }//left
        else if (horizontalInput < 0 || position.y < minY)
        {
            controllerUI.FillUpSelection();
            controllerUI.ChangeSprite(ControllerPosition.Left, ControllerType.Keyboard);
            controllerUI.flowchart.SetStringVariable("Direction", "Left");
            glass.MoveLeft();
        }
        else
        {
            controllerUI.FillDownSelection();
            controllerUI.ChangeSprite(ControllerPosition.Default, ControllerType.Keyboard);
            controllerUI.flowchart.SetStringVariable("Direction", "None");
            glass.ResetPosition();
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
                if (value != "" && value != null)
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
        }
    }
}
