using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Sprite[] asteroidSprites;
    public float spawnInterval = 2f;  

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0f, spawnInterval);
    }

    void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab);

        if (asteroidSprites.Length > 0)
        {
            Sprite randomSprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];
            asteroid.GetComponent<SpriteRenderer>().sprite = randomSprite;
        }
    }
}
