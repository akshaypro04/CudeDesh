using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Music[] Musics;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.name = s.Name;
            s.audioSource.loop = s.Loop;
        }

        foreach (Music m in Musics)
        {
            m.audioSource = gameObject.AddComponent<AudioSource>();
            m.audioSource.clip = m.clip;
            m.audioSource.volume = m.volume;
            m.audioSource.name = m.Name;
            m.audioSource.loop = m.Loop;
        }
    }


    void Start()
    {
        PlayMusic("theme");
    }


    public void PlaySfx(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        if(s == null)
        {
            print("Can not find " + name + " sfx");
            return;
        }
        if (s.audioSource.isPlaying == true)
            return;
        s.audioSource.Play();
    }

    public void PlayMusic(string name)
    {
        Music m = Array.Find(Musics, M => M.Name == name);

        if (m == null)
        {
            print("Can not find " + name + " music");
            return;
        }
        if (m.audioSource.isPlaying == true)
            return;
        m.audioSource.Play();
    }
}
