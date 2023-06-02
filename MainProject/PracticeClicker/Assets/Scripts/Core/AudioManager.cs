using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip[] _scenesMusic;
    [SerializeField] private AudioSource _musicPrefab;

    public static AudioManager instance;
    public static Action OnSoundVolumeChange;
    private AudioSource _music;

    private void Awake()
    {
        if (instance is not null && instance != this)
        {
            if (_music is not null) Destroy(_music.gameObject);
            Destroy(gameObject);
        }
        else if(instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        _music = Instantiate(_musicPrefab).GetComponent<AudioSource>();
        _music.transform.parent = null;

        _music.volume = MusicVolume;
        if (_scenesMusic is not null && _scenesMusic.Length > 0) 
        {
            _music.clip = _scenesMusic[0];
            _music.Play();
        }

        DontDestroyOnLoad(_music.gameObject);
    }
    
    private void OnLevelWasLoaded(int level)
    {
        if (_scenesMusic.Length > level && _scenesMusic[level] != null)
        {
            if (_music.clip is null || _scenesMusic[level].name != _music.clip.name)
            {
                _music.clip = _scenesMusic[level];
                _music.Play();
            }
        }
        else
        {
            _music.clip = null;
        }
    }

    public void MuteAudio(bool value)
    {
        Mute = value;
    }
    public void MusicVolumeChange(float value)
    {
        MusicVolume = value;
    }
    public void SoundVolumeChange(float value)
    {
        SoundVolume = value;
        OnSoundVolumeChange?.Invoke();
    }


    public bool Mute
    {
        get
        {
            return PlayerPrefs.GetInt("Mute", 0) == 1 ? true : false;
        }
        set
        {
            _music.mute = !value;
            PlayerPrefs.SetInt("Mute", value ? 1 : 0);
        }
    }

    public float SoundVolume
    {
        get
        {
            return PlayerPrefs.GetFloat("Sound", 1f);
        }
        set
        {
            PlayerPrefs.SetFloat("Sound", (float)value);
        }
    }

    public float MusicVolume
    {
        get
        {
            return PlayerPrefs.GetFloat("Music", 0.5f);
        }
        set
        {
            PlayerPrefs.SetFloat("Music", (float)value);
            _music.volume = PlayerPrefs.GetFloat("Music", 0.5f);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
