using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource destroySound;
    private int speed = 6;
    public float bottomScreen = -6f;

    void Start()
    {
        destroySound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        // Set a random position along the top of the screen
        Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), 6f); // Adjust range based on your screen width
        transform.position = randomPosition;

        // Set a random direction for movement
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
        rb.linearVelocity = randomDirection * speed;
    }

    void Update()
    {
        if(transform.position.y < bottomScreen)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            ScoreScript.scoreValue += 10;
            destroySound.Play();
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}
