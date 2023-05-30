using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    void Start()
    {
        _musicSlider.value = AudioManager.instance.MusicVolume;
        _soundSlider.value = AudioManager.instance.SoundVolume;

        _musicSlider.onValueChanged.AddListener(AudioManager.instance.MusicVolumeChange);
        _soundSlider.onValueChanged.AddListener(AudioManager.instance.SoundVolumeChange);
    }
}
