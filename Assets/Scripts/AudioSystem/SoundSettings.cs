using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public struct AudioSettingSaveData
{
    public float masterVolume;
    public float musicVolume; 
    public float soundVolume;
}

public class SoundSettings : MonoBehaviour
{
    public static SoundSettings instance;

    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SoundfxSlider;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CallLoadAudioData();
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("SoundFXVolume", volume);
    }

    public void UpdateMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void CallSaveAudioData()
    {
        SaveSystem.Save();
    }

    public void CallLoadAudioData()
    {
        SaveSystem.Load();
    }

    public void Save(ref AudioSettingSaveData data)
    {
        // Get Master Volume
        audioMixer.GetFloat("MasterVolume", out float masterVol);
        data.masterVolume = masterVol;

        // Get Music Volume
        audioMixer.GetFloat("MusicVolume", out float musicVol);
        data.musicVolume = musicVol;

        // Get Sound FX Volume
        audioMixer.GetFloat("SoundFXVolume", out float soundVol);
        data.soundVolume = soundVol;
    }

    public void Load(AudioSettingSaveData data)
    {
        musicSlider.value = data.musicVolume;
        SoundfxSlider.value = data.soundVolume;
        masterSlider.value = data.masterVolume;
    }
}
