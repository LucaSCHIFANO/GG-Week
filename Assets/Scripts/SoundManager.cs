using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using Fungus;
using UnityEngine.SceneManagement;

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

            try
            {
                flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            }
            catch
            {
                Debug.Log("Sound Manager = No Flow Chart");
            }

            //LevelManager.cs
            GameEvents.sceneIsLoaded.AddListener(PlayBackgroundSound);

        }
        else
        {
            Destroy(this.gameObject);
        }
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

    private void PlayBackgroundSound()
    {
        StopAllSound();
        Scene scene = SceneManager.GetActiveScene();
        Sound s = Array.Find(sounds, sound => sound.name == scene.name);
        if (s == null) { return; }
        s.source.Play();

        string soundName = "Ambient" + scene.name;
        Debug.Log("sound Name = " + soundName);
        Sound ambient = Array.Find(sounds, sound => sound.name == "Ambient" + scene.name);
        if(ambient == null) { return; }
        ambient.source.Play();
    }

    private void StopAllSound()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }


    public void timeToPlay()
    {
        string name = flowchart.GetStringVariable("musicName");
        PlaySound(name);
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