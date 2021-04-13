using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SliderScript : MonoBehaviour
{
    public SoundType type;
    SoundManager soundManager;
    Sound[] sounds;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        sounds = soundManager.sounds;
    }
    public void SetVolume(float sliderValue)
    {
        foreach (Sound s in sounds)
        {
            if(s.type == type)
            {
                s.volume = sliderValue;
                s.source.volume = sliderValue;
                Debug.Log("Set Volume of " + type);
            }
        }
    }
    
}
