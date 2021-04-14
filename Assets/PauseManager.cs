using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject layer_pause;
    public GameObject layer_Options;
    public GameObject layer_Sound;
    public GameObject layer_Video;
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

        if (!pause)
        {
            layer_Options.SetActive(false);
            layer_Sound.SetActive(false);
            layer_Video.SetActive(false);
        }
    }
}
