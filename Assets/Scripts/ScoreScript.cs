using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        score.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
}