using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle soundToggle;

    void Start()
    {
        // Initialize UI with saved preferences
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        volumeSlider.value = savedVolume;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(savedVolume) * 20);

        bool soundOn = PlayerPrefs.GetInt("SoundEnabled", 1) == 1;
        soundToggle.isOn = soundOn;
        audioMixer.SetFloat("MasterVolume", soundOn ? Mathf.Log10(savedVolume) * 20 : -80f);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void ToggleSound(bool soundOn)
    {
        float volume = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        audioMixer.SetFloat("MasterVolume", soundOn ? Mathf.Log10(volume) * 20 : -80f);
        PlayerPrefs.SetInt("SoundEnabled", soundOn ? 1 : 0);
    }


}