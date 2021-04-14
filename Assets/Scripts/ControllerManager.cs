using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public Controller controller;
    public WineSimulation glass;

    private bool controllerIsActive = false;
    private void Awake()
    {
        GameEvents.hasNotArduino.AddListener(ActivateController);
    }
    private void Update()
    {
        if (!controllerIsActive) { return; }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Debug.Log("controller is active");
        //up
        if (verticalInput > 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Up, ControllerType.Keyboard);
            glass.MoveUp();
        }//down
        else if (verticalInput < 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Down, ControllerType.Keyboard);
            glass.MoveDown();
        }//right
        else if (horizontalInput > 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Right, ControllerType.Keyboard);
            glass.MoveRight();
        }//left
        else if (horizontalInput < 0)
        {
            controller.FillUpSelection();
            controller.ChangeSprite(ControllerPosition.Left, ControllerType.Keyboard);
            glass.MoveLeft();
        }
        else
        {
            controller.FillDownSelection();
            controller.ChangeSprite(ControllerPosition.Default, ControllerType.Keyboard);
            glass.ResetPosition();
        }
    }

    private void ActivateController()
    {
        controllerIsActive = true;
    }
}
