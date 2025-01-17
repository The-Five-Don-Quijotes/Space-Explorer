using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject laser;
    public int score;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    private float halfPlayerSizeX;
    private float halfPlayerSizeY;
    private Vector3 respawnPosition;
    public GameObject instantiatedshipPrefab;
    [SerializeField] private GameObject shipPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        halfPlayerSizeX = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        halfPlayerSizeY = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from the Horizontal and Vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal") * 10f;
        float moveVertical = Input.GetAxis("Vertical") * 10f;
        clampPlayerMovement();

        // Create a new velocity vector
        Vector2 newVelocity = new Vector2(moveHorizontal, moveVertical);

        // Assign the new velocity to the Rigidbody2D
        rb.linearVelocity = newVelocity;

        cooldownTimer -= Time.deltaTime;

        //Press shoot (space or left click)
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && cooldownTimer <= 0)
        {
            //Creates a new instance(clone) of the laser
            cooldownTimer = fireDelay;
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }

    //prevent ship go outside of screen boundaries
    void clampPlayerMovement()
    {
        Vector3 position = transform.position;

        float distance = transform.position.z - Camera.main.transform.position.z;

        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + halfPlayerSizeX;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance)).x - halfPlayerSizeX;


        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance)).y + halfPlayerSizeY;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance)).y - halfPlayerSizeY;
        position.x = Mathf.Clamp(position.x, leftBorder, rightBorder);
        position.y = Mathf.Clamp(position.y, bottomBorder, topBorder);

        transform.position = position;
    }

    //collision and respawn trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Star"))
        {
            ScoreScript.scoreValue += 20;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Asteriod"))
        {
            Debug.Log("Ship hit by an asteroid!");
            ScoreScript.scoreValue -= 10;
            respawnPosition = transform.position;
            gameObject.SetActive(false);
            Invoke("Respawn", 0.5f);
        }
    }

    private void Respawn()
    {
        // Reactivate the ship
        gameObject.SetActive(true);

        // Make the ship invulnerable
        StartCoroutine(TemporaryInvulnerability(3f));
    }

    private IEnumerator TemporaryInvulnerability(float duration)
    {
        Collider2D shipCollider = GetComponent<Collider2D>();
        SpriteRenderer shipRenderer = GetComponent<SpriteRenderer>();
        float blinkInterval = 0.2f;

        if (shipCollider != null)
        {
            shipCollider.enabled = false; // Disable the collider
            Debug.Log("Ship is invulnerable.");
        }

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            if (shipRenderer != null)
            {
                shipRenderer.enabled = !shipRenderer.enabled;
            }

            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval); // blink delay
        }

        if (shipRenderer != null)
        {
            shipRenderer.enabled = true; 
        }

        if (shipCollider != null)
        {
            shipCollider.enabled = true; // Re-enable the collider
            Debug.Log("Ship is now vulnerable.");
        }
    }

}
