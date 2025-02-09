using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInput : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject enterNamePanel;
    public TextMeshProUGUI displayNameText;

    private string playerName = "";

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
    }
}
