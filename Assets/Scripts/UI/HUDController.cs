using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public PlayerStats stats;
    public Image healthBar;
    public TextMeshProUGUI counterText;

    private void Update()
    {
        if (stats == null) return;

        UpdateHealthBar();

        healthBar.fillAmount = (float)stats.health / stats.maxHealth;

        counterText.text = $"Contador: {stats.score}";
    }

    public void UpdateHealthBar()
    {
        if (stats.health > 70)
        {
            healthBar.color = Color.green;
        }
        else if (stats.health > 50f)
        {
            healthBar.color = Color.yellow;
        }
        else if (stats.health > 25f)
        {
            healthBar.color = Color.orange;
        }
        else
        {
            healthBar.color = Color.red;
        }
    }
}
