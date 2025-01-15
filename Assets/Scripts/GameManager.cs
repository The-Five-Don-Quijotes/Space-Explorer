using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shipPrefab; // Assign the Ship prefab in the Inspector

    // Spawns the ship at the given position
    public void SpawnShip(Vector3 respawnPosition)
    {
        Instantiate(shipPrefab, respawnPosition, Quaternion.identity);
        Debug.Log("Ship respawned at position: " + respawnPosition);
    }
}
