using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MasterSliderScript : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetMasterVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        Debug.Log("Set Master Volume");
    }
}
