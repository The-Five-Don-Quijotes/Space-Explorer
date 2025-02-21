using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnStar", 0f, spawnInterval);
    }

    public void SpawnStar()
    {
        Instantiate(starPrefab);
    }
}
