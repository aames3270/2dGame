using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{   // Reference to ball spawn prefab
    public GameObject ballPrefab; 
    // Time (seconds) between ball spawns
    public float initialSpawn = 1.5f; 
    // Min time interval between spawns
    public float minimumSpawn = 0.005f; 
    // Rate at which the spawn intervals decrease over time
    public float decreaseRate = 0.5f; 
    // Probability that two ball will spawn at the same time
    public float doubleSpawn = 0.2f;
    // Holds current spawn interval
    private float currentSpawn;
    // Keeps track of time passed since last ball
    private float timeSinceLastSpawn;
    // Component for playing sound effects
    private AudioSource audioSource;
    // Sound effects
    public AudioClip singleBall;
    public AudioClip doubleBall;
   
    
    // Method is called when script is first ran

    void Start()
    {
        // Get audio attached to this object
        audioSource = GetComponent<AudioSource>();
        // Initialize spawn interval to starting value
        currentSpawn = initialSpawn;
        // Initialize the time since last spawn
        timeSinceLastSpawn = 0f;
    }
    // Called once per frame
    void Update()
    {
        // Increase the timer that tracks the time since last spawn
        timeSinceLastSpawn += Time.deltaTime;
        // check if enough time has passed to spawn new ball
        if (timeSinceLastSpawn >= currentSpawn)
        {
            // spawns ball   
            SpawnBall();
            // Reset the timer for next spawn
            timeSinceLastSpawn = 0f;
            // Gradually decrease the spawn interval to make balls spawn faster
            if (currentSpawn > minimumSpawn)
            {
                // Reduce spawn interval
                currentSpawn -= decreaseRate * Time.deltaTime;
            }
        }
    }
    // Method that handles the actual ball spawn
    void SpawnBall()
    {
        // Generate random x position 
        float spawnX = Random.Range(-3f, 3f); 
        // Define spawn position for ball
        Vector2 spawnPosition = new Vector2(spawnX, 6f); 
        // Create new ball at the generated position
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        // If a second ball should spawn, based on random value and double spawn probability
        if (Random.value < doubleSpawn)
        {
            // Generate a different random x position for second ball
            float secondSpawnX = Random.Range(-3f, 3f); 
            // Define position for second ball
            Vector2 secondSpawnPosition = new Vector2(secondSpawnX, 6f);
            // Spawn the second ball at generated position
            Instantiate(ballPrefab, secondSpawnPosition, Quaternion.identity);
            // Play the sound for spawning two balls
            if (doubleBall != null)
            {
                audioSource.PlayOneShot(doubleBall);
            }
        }
        else
        {
            // Play the sound for spawning one ball
            if (singleBall != null)
            {
                audioSource.PlayOneShot(singleBall);
            }
        }
    }
}



