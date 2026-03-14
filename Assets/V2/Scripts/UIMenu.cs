using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public Slider musica;
    public Slider sfx;
    public Toggle musicaON;

    private void Start()
    {
        musica.value = GameManager.instance.VMusica;
        sfx.value = GameManager.instance.VSfx;
        musicaON.isOn = GameManager.instance.mute;
    }
    public void SettingsChangeMusica()
    {
        GameManager.instance.VMusica = musica.value;
        changesAudio();
    }
    public void SettingChangeSFX()
    {
        GameManager.instance.VSfx = sfx.value;
        changesAudio();
    }
    public void SettingChangeMute()
    {
        GameManager.instance.mute = musicaON.isOn;
        changesAudio();
    }
    public void changesAudio()
    {
        AudioManager.instance.SetMusica();
    }
}
