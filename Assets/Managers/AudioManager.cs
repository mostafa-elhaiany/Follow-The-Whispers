using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public int background;
    public AudioMixer mixer;

    [Range(-80, 20)]
    public float masterVolume;
    [Range(-80, 20)]
    public float ambientVolume;
    [Range(-80, 20)]
    public float speechVolume;
    [Range(-80, 20)]
    public float effectVolume;
    [Range(-80, 20)]
    public float whisperVolume;


    float whisperSounds;

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

        GameManager.mainSound = masterVolume;
        GameManager.effectsSound = effectVolume;
        GameManager.speechSound = speechVolume;
        GameManager.whisperSound = whisperVolume;


        mixer.SetFloat("masterVolume", GameManager.mainSound);
        mixer.SetFloat("effectVolume", GameManager.effectsSound);
        mixer.SetFloat("speechVolume", GameManager.speechSound);
        mixer.SetFloat("whisperVolume", GameManager.whisperSound);

    }

    public void setWhisperSound(float val)
    {
        whisperVolume = val;
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