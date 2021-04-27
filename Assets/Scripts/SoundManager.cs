using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using Fungus;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    public Flowchart flowchart;

    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.outputAudioMixerGroup = Resources.Load<AudioMixerGroup>("Audio/MasterVolumeMixer");
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.spatialBlend = s.spatialBlend;
                s.source.minDistance = s.minDist3D;
                s.source.maxDistance = s.maxDist3D;
                s.source.mute = s.mute;
                s.source.loop = s.loop;
                s.source.playOnAwake = s.playOnAwake;
            }

            flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

        //Add the music to play at start
        //Sound s = Array.Find(sounds, sound => sound.name == "Background");
        //if (s == null) { return; }
        //s.source.Play();        

    }

    //How to use : FindObjectOfType<SoundManager>().PlaySound(name);
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found !\nCheck name spelling");
            return;
        }
        s.source.Play();
    }


    public void timeToPlay()
    {
        string name = flowchart.GetStringVariable("musicName");
        FindObjectOfType<SoundManager>().PlaySound(name);
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public SoundType type;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 0.1f;
    [Range(-3f, 3f)]
    public float pitch = 1.0f;
    [Range(0f, 1f)]
    public float spatialBlend = 0f;
    public float minDist3D = 1f;
    public float maxDist3D = 500f;
    public bool mute = false;
    public bool loop = false;
    public bool playOnAwake = true;

    [HideInInspector]
    public AudioSource source;
}

public enum SoundType{
    MUSIC,
    SOUNDEFFECT,
    ENVIRONMENT,
    UIEFFECT,
}