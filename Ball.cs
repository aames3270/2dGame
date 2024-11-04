using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variable for the initial speed for which the ball falls
    public float fallSpeed = 2f; 
    // Variable for control how fast speed increases over time
    private float difficultyIncreaseRate = 2f; 
    // Called once per frame...
    void Update()
    {
        // Move ball downwards at the current fall speed
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        // Increase the speed over time
        fallSpeed += difficultyIncreaseRate * Time.deltaTime;   
        // check if ball has fallen off the bottom of the screen
        if (transform.position.y < -6f)
        {
            // Destroy ball
            Destroy(gameObject);
        }
    }
}

