using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public int background;
    public AudioMixer mixer;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.outputAudioMixerGroup = s.group;
        }

    }

    void Start()
    {
        if (!GameManager.mute)
            play(sounds[background].name);
    }

    void Update()
    {
        mixer.SetFloat("master", GameManager.mainSound);
        mixer.SetFloat("effects", GameManager.effectsSound);
        mixer.SetFloat("speech", GameManager.speechSound);

    }


    public void play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound name " + soundName + " Does not exist!");
            return;
        }
        s.source.Play();
    }


    public void stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound name " + soundName + " Does not exist!");
            return;
        }
        s.source.Stop();
    }
}