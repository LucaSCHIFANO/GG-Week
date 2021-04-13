using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

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

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

        //Add the music to play at start
        Sound s = Array.Find(sounds, sound => sound.name == "Background");
        if (s == null) { return; }
        s.source.Play();
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
}

[System.Serializable]
public class Sound
{
    public string name;
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