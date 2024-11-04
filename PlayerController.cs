using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private bool isHit = false; // To track if the player has been hit
    

    public GameObject explosionPrefab;

    // Define movement boundaries
    private float minX = -2f;
    private float maxX = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isHit)
        {
            // Allow movement only if the player has not been hit
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * speed, rb.velocity.y);

            // Clamp the player's position within the boundaries
            float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
            rb.position = new Vector2(clampedX, rb.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Call the Hit method when the player collides with a ball
            Hit();
        }
    }

    void Hit()
    {
        isHit = true; // Set the player to "hit" state
        rb.gravityScale = 1f; // Enable gravity to make the player fall
        rb.velocity = Vector2.zero; // Stop any movement before falling
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Play the explosion sound
        AudioSource explosionAudio = explosion.GetComponent<AudioSource>();
        if (explosionAudio != null)
        {
            explosionAudio.Play();
        }

        // Inform the GameManager that the player was hit
        FindObjectOfType<GameManager>().EndGame();
        Destroy(gameObject);
    }
}

