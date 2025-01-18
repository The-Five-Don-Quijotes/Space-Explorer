using TMPro;
using UnityEngine;

public class TotalScoreDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        Debug.Log("Total score invoked");
        finalScoreText.text = "Total Score:" + ScoreScript.scoreValue;
    }
}
