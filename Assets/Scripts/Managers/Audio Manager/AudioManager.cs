using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        this.Play("MenuMusic");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    public void Regulate(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.volume = volume;
    }
    public float GetVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return 0;

        return s.source.volume;
    }
    public void StopMusic()
    {
        Sound GameMusic = Array.Find(sounds, sound => sound.name == "GameMusic");
        Sound MenuMusic = Array.Find(sounds, sound => sound.name == "MenuMusic");
        if (GameMusic == null)
            return;
        if (MenuMusic == null)
            return;
        GameMusic.source.Stop();
        MenuMusic.source.Stop();
        GameMusic.source.volume = 0;
        MenuMusic.source.volume = 0;
    }
    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();          
        }
    }
}
