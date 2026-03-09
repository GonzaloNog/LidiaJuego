using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public int score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = PlayerPrefs.GetInt("health", maxHealth);
        score = PlayerPrefs.GetInt("score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleHealth();
        HandleCounter();
        DebugDeletePlayerPrefs();
    }

    void HandleHealth()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            health = Mathf.Max(0, health - 15);

            PlayerPrefs.SetInt("Health", health);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            health = Mathf.Min(100, health + 10);

            PlayerPrefs.SetInt("health", health);
        }

        
    }

    void HandleCounter()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            score++;

            PlayerPrefs.SetInt("score", score);
        }
    }

    void DebugDeletePlayerPrefs()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
