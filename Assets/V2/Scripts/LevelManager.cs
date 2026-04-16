using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Combate combate;
    public Camera[] cams;
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

    public void camaraSwitch(string cod)
    {
        for(int a = 0; a < cams.Length; a++)
        {
            cams[a].gameObject.SetActive(false);
        }
        switch(cod)
        {
            case "explorar":
                cams[0].gameObject.SetActive(true);
                break;
            case "combate":
                cams[1].gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Error en el codigo de camaras");
                break;
        }
    }
}
