using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
   public void PlayGame(int nivel)
   {
        SceneManager.LoadScene(nivel);
   }
    public void QuitGame()
    {
        Application.Quit();
    }
}
