using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ControllerUI : MonoBehaviour
{
    public float timeToFill = 0.5f;


    public InputType[] control = new InputType[4];

    public Flowchart flowchart;
    ProgressBar progressBar;
    Image controllerUI_Image;

    private float min = 0.0f;
    private float current = 0.0f;

    private void Awake()
    {
        controllerUI_Image = GameObject.Find("ControllerUI_Image").GetComponent<Image>();
        progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
    }
    private void Start()
    {
        progressBar.max = timeToFill;
        progressBar.min = min;
        progressBar.current = current;
        progressBar.SetCurrentFill(current);
    }
    private void Update()
    {
        progressBar.max = timeToFill;
        if (flowchart != null)
        {
            if (current < 0)
            {
                current = 0;
            }
            flowchart.SetFloatVariable("Fill", current);
        }

    }

    public void ChangeSprite(ControllerPosition position, ControllerType type)
    {
        int index = 0;
        foreach (InputType inputType in control)
        {
            if (inputType.controlType == type)
            {
                break;
            }

            index++;
        }

        foreach (InputCommande inputCommande in control[index].commande)
        {
            if (inputCommande.position == position)
            {
                controllerUI_Image.sprite = inputCommande.sprite;
            }
        }
    }
    public void FillUpSelection()
    {
        if (current <= timeToFill)
        {
            current += Time.deltaTime;
            progressBar.SetCurrentFill(current);
            //Debug.Log("Fill up to = " + current);
        }
    }

    public void FillDownSelection()
    {
        if (current >= min)
        {
            current -= Time.deltaTime;
            progressBar.SetCurrentFill(current);
        }
    }

    public Flowchart GetFlowchart()
    {
        return this.flowchart;
    }
}

[System.Serializable]
public class InputType
{
    public string name;
    public ControllerType controlType = ControllerType.Keyboard;
    public InputCommande[] commande = new InputCommande[5];

    public InputType()
    {
        commande[0] = new InputCommande("Default", ControllerPosition.Default);
        commande[1] = new InputCommande("Up", ControllerPosition.Up);
        commande[2] = new InputCommande("Down", ControllerPosition.Down);
        commande[3] = new InputCommande("Left", ControllerPosition.Left);
        commande[4] = new InputCommande("Right", ControllerPosition.Right);
    }
}

[System.Serializable]
public class InputCommande
{

    public string name;
    public Sprite sprite;
    public ControllerPosition position = ControllerPosition.Default;

    public InputCommande(string _name, ControllerPosition _position)
    {
        this.name = _name;
        this.position = _position;
    }
}

public enum ControllerType
{
    Keyboard,
    Mouse,
    Joystick,
    WineGlass
}

public enum ControllerPosition
{
    Up,
    Down,
    Left,
    Right,
    Default
}


