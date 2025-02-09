using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTopTenPlayers : MonoBehaviour
{
    private DatabaseManagement db;
    public Text leaderboardText; // Gán UI Text vào đây

    void Start()
    {
        db = FindFirstObjectByType<DatabaseManagement>();
        if (db == null)
        {
            Debug.LogError("DatabaseManagement không được tìm thấy trong scene!");
            return;
        }

        DisplayTopTenPlayers();
    }

    void DisplayTopTenPlayers()
    {
        List<(string Username, int Score)> topPlayers = db.GetTopTenScores();
        string leaderboardString = "<b>🏆 Top 10 Players 🏆</b>\n\n";

        for (int i = 0; i < topPlayers.Count; i++)
        {
            leaderboardString += $"{i + 1}. <b>{topPlayers[i].Username}</b> - {topPlayers[i].Score}\n";
        }

        if(leaderboardString.Length > 0)
        {
            leaderboardText.text = leaderboardString;
        }
    }
}
