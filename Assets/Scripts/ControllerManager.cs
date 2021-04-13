using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public Controller controller;
    public WineSimulation glass;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

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
}
