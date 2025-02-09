using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Mono.Data.Sqlite;

namespace Assets.Scripts
{
    public class DatabaseManagement : MonoBehaviour
    {
        private string dbPath;

        void Awake()
        {
            dbPath = Path.Combine(Application.persistentDataPath, "Score.sqlite");
            Debug.Log($"📂 Database path: {dbPath}");
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    SqliteConnection.CreateFile(dbPath);
                }
                using (var conn = new SqliteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand("CREATE TABLE IF NOT EXISTS Score (Username TEXT PRIMARY KEY, Score INTEGER NOT NULL)", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                Debug.Log("Database Initialized!");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error initializing database: {ex.Message}");
            }
        }

        public void InsertOrUpdateScore(string username, int score)
        {
            if (string.IsNullOrEmpty(username)) return;

            try
            {
                using (var conn = new SqliteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    using (var checkCmd = new SqliteCommand("SELECT Score FROM Score WHERE Username = @username", conn))
                    {
                        checkCmd.Parameters.Add(new SqliteParameter("@username", username));
                        object result = checkCmd.ExecuteScalar();

                        if (result != null && Convert.ToInt32(result) >= score)
                        {
                            Debug.Log("New score is lower or equal, no update made.");
                            return;
                        }

                        using (var cmd = new SqliteCommand(result == null ?
                            "INSERT INTO Score (Username, Score) VALUES (@username, @score)" :
                            "UPDATE Score SET Score = @score WHERE Username = @username", conn))
                        {
                            cmd.Parameters.Add(new SqliteParameter("@username", username));
                            cmd.Parameters.Add(new SqliteParameter("@score", score));
                            cmd.ExecuteNonQuery();
                            Debug.Log(result == null ? "New Score Inserted!" : "Score Updated!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error inserting/updating score: {ex.Message}");
            }
        }

        public List<(string Username, int Score)> GetTopTenScores()
        {
            List<(string, int)> topPlayers = new List<(string, int)>();

            try
            {
                using (var conn = new SqliteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    using (var cmd = new SqliteCommand("SELECT Username, Score FROM Score ORDER BY Score DESC LIMIT 10", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            int score = Convert.ToInt32(reader["Score"]);
                            topPlayers.Add((username, score));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error retrieving top 10 scores: {ex.Message}");
            }

            return topPlayers;
        }
    }
}