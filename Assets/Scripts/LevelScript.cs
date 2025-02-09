using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class LevelScript : MonoBehaviour
{
    public static int levelValue = 0;
    private TextMeshProUGUI level;

    void Start()
    {
        level = GetComponent<TextMeshProUGUI>();
        levelValue++;
        level.text = "Level " + levelValue;

        Invoke("LoadNextScene", 0.5f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Ingame Scence");
    }
}
