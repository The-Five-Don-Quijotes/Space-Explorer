using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Assign your asteroid prefab in the Inspector
    public float spawnInterval = 2f;  // Time between spawns

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0f, spawnInterval);
    }

    void SpawnAsteroid()
    {
        Instantiate(asteroidPrefab);
    }
}
