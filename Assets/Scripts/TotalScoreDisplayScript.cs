using TMPro;
using UnityEngine;

public class TotalScoreDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI playerNameText;

    private void Start()
    {
        Debug.Log("Total score invoked");
        finalScoreText.text = "Total Score:" + ScoreScript.scoreValue;
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        playerNameText.text = "Player: " + playerName;
    }
}
