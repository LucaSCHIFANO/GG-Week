using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public Controller controller;
    public WineSimulation glass;
    public ArduinoTest arduino;

    private bool controllerIsActive = false;
    private void Awake()
    {
        GameEvents.hasNotArduino.AddListener(ActivateController);
    }
    private void Update()
    {
        if(arduino.hasStreamOpen == true) { return; }
        //if (!controllerIsActive) { return; }
        //Debug.Log("controller is active");

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        //up
        if (verticalInput > 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Up, ControllerType.Keyboard);
            controller.flowchart.SetStringVariable("Direction", "Up");
            glass.MoveUp();
        }//down
        else if (verticalInput < 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Down, ControllerType.Keyboard);
            controller.flowchart.SetStringVariable("Direction", "Down");
            glass.MoveDown();
        }//right
        else if (horizontalInput > 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Right, ControllerType.Keyboard);
            controller.flowchart.SetStringVariable("Direction", "Right");
            glass.MoveRight();
        }//left
        else if (horizontalInput < 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Left, ControllerType.Keyboard);
            controller.flowchart.SetStringVariable("Direction", "Left");
            glass.MoveLeft();
        }
        else
        {
            controller.FillDownSelection();
            controller.ChangeSprite(ControllerPosition.Default, ControllerType.Keyboard);
            glass.ResetPosition();
            controller.flowchart.SetStringVariable("Direction", "None");
        }
    }

    private void ActivateController()
    {
        controllerIsActive = true;
        Debug.Log("Activate Controller");
    }
}
