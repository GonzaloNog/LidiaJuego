using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float VMusica;
    public float VSfx;
    public bool mute;
    public float mouseSensitivity = 100;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
