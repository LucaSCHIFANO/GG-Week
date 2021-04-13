using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject layer_pause;
    private bool pause = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            ChangePauseScreen();
        }
    }

    public void ChangePauseScreen()
    {
        pause = !pause;
        layer_pause.SetActive(pause);
    }
}
