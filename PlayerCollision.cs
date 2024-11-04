using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            // Call the EndGame method from the GameManager
            gameManager.EndGame();
        }
    }
}