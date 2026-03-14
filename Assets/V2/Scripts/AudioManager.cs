using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSourceMusica;
    public AudioSource audioSourceSfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        SetMusica();
    }

    public void SetMusica()
    {
        if (GameManager.instance.mute)
        {
            audioSourceMusica.volume = 0;
        }
        else
        {
            audioSourceMusica.volume = GameManager.instance.VMusica;
        }
    }

    public void SetSFX()
    {

    }

}
