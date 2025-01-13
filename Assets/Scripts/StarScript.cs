using UnityEngine;

public class StarScript : MonoBehaviour
{
    Rigidbody2D rb;
    private int speed = 6;
    public float bottomScreen = -6f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set a random position along the top of the screen
        Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), 6f); // Adjust range based on your screen width
        transform.position = randomPosition;

        // Set a downward direction for movement
        rb.linearVelocityY = -speed;
    }

    void Update()
    {
        if (transform.position.y < bottomScreen)
        {
            Destroy(gameObject);
        }
    }
}
