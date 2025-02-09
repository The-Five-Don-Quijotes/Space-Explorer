using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;

public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject enterNamePanel;
    public TextMeshProUGUI displayNameText;
    private DatabaseManagement db;

    private string playerName = "";

    void Start()
    {
        db = FindFirstObjectByType<DatabaseManagement>();
        if (db == null)
        {
            Debug.LogError("DatabaseManagement không được tìm thấy trong scene!");
        }
    }

    public void SubmitName()
    {
        playerName = nameInputField.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        displayNameText.text = playerName;
        enterNamePanel.SetActive(false);
        if(ScoreScript.scoreValue == null)
        {
            Debug.LogError("Score không được tìm thấy trong scene!");
        }
        int score = ScoreScript.scoreValue;

        db.InsertOrUpdateScore(playerName, score);
    }
}
