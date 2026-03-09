using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool IsPaused { get; private set; } = false;

    public GameObject pauseMenuUI;
    public GameObject uiHUD;
    public GameObject optionsPanel;

    void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) Resume(); else Pause();
        }
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);
        else
            Debug.LogWarning("PauseMenuUI is missing or destroyed.");

        if (uiHUD != null)
            uiHUD.SetActive(false);
        else
            Debug.LogWarning("HUD is missing or destroyed.");

        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);
        else
            Debug.LogWarning("PauseMenuUI is missing or destroyed.");

        if (uiHUD != null)
            uiHUD.SetActive(true);
        else
            Debug.LogWarning("HUD is missing or destroyed.");

        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void GoToMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
    }
}
