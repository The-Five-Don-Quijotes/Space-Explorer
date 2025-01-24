using TMPro;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public static int lifeValue = 3; // Static value to track lives
    TextMeshProUGUI lifeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeText = GetComponent<TextMeshProUGUI>();
        lifeText.text = "Lives: " + lifeValue;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Lives: " + lifeValue;
    }

    // Method to decrease life (can be called from ShipScript or elsewhere)
    public static void DecreaseLife()
    {
        if (lifeValue > 0)
        {
            lifeValue--;
        }
    }

    // Optional: Method to reset lives (e.g., when restarting the game)
    public static void ResetLives(int initialLives)
    {
        lifeValue = initialLives;
    }
}
