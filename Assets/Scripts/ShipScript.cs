using Unity.VisualScripting;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject laser;
    public int score;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the Horizontal and Vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal") * 10f;
        float moveVertical = Input.GetAxis("Vertical") * 10f;

        // Create a new velocity vector
        Vector2 newVelocity = new Vector2(moveHorizontal, moveVertical);

        // Assign the new velocity to the Rigidbody2D
        rb.linearVelocity = newVelocity;

        cooldownTimer -= Time.deltaTime;

        //Press shoot (space or left click)
        if((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && cooldownTimer <= 0)
        {
            //Creates a new instance(clone) of the laser
            cooldownTimer = fireDelay;
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
}
