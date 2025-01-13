using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = speed;
    }

    void OnBecameInvisible()
    {
        //Destroy the laser when it goes out the screen
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
