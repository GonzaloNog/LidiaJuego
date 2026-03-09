using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider musicSlider;
    public Toggle muteToggle;
    private const string MUSIC_PARAM = "MusicVolume";
    private const string PREF_MUSIC = "MusicVolumePref";
    private const string PREF_MUTE = "MusicMutePref";
    private const float DB_MIN = -88f;
    private const float DB_MAX = 0f;


    void Start()
    {
        if (musicSlider != null)
        {
            musicSlider.onValueChanged.AddListener(OnMusicSlider);
        }

        if (muteToggle != null)
        {
            muteToggle.onValueChanged.AddListener(OnMuteToggle);
        }
            
        LoadAudioSettings();
    }

    private void LoadAudioSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat(PREF_MUSIC, 1f);
        bool savedMute = PlayerPrefs.GetInt(PREF_MUTE, 0) == 1;

        if (musicSlider != null)
        {
            musicSlider.value = savedMute ? 0f : savedVolume;
        }

        if (muteToggle != null)
        {
            muteToggle.isOn = savedMute;
        }

        ApplyVolume(savedVolume, savedMute);
    }

    private void ApplyVolume(float sliderValue, bool isMuted)
    {
        if (mainMixer == null)
        {
            return;
        }

        float dB = isMuted ? DB_MIN : Mathf.Lerp(DB_MIN, DB_MAX, sliderValue);

        mainMixer.SetFloat(MUSIC_PARAM, dB);
    }

    public void OnMusicSlider(float sliderValue)
    {

        bool isMuted = (muteToggle != null && muteToggle.isOn);

        ApplyVolume(sliderValue, isMuted);

        PlayerPrefs.SetFloat(PREF_MUTE, sliderValue);

        PlayerPrefs.Save();
    }

    public void OnMuteToggle(bool isMuted)
    {
        float sliderValue = (musicSlider != null) ? musicSlider.value : 1f;

        ApplyVolume(sliderValue, isMuted);

        PlayerPrefs.SetInt(PREF_MUTE, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
