using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ProgressBar progressBar;
    public float timeToFill;

    private float min = 0.0f;
    private float current = 0.0f;

    private void Start()
    {
        progressBar.max = timeToFill;
        progressBar.min = min;
        progressBar.current = current;
        progressBar.SetCurrentFill(current);
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //up
        if (verticalInput == 1)
        {
            Debug.Log("Up");
            FillUpSelection();
        }//down
        else if (verticalInput == -1)
        {
            Debug.Log("Down");
            FillUpSelection();
        }//right
        else if (horizontalInput == 1)
        {
            Debug.Log("Right");
            FillUpSelection();
        }//left
        else if (horizontalInput == -1)
        {
            Debug.Log("Left");
            FillUpSelection();
        }
        else
        {
            FillDownSelection();
        }

        progressBar.max = timeToFill;
    }

    private void FillUpSelection()
    {
        if(current > timeToFill) { return; }


        current += Time.deltaTime;
        progressBar.SetCurrentFill(current);
    }

    private void FillDownSelection()
    {
        if (current < min) { return; }

        current -= Time.deltaTime;
        progressBar.SetCurrentFill(current);
    }
}
