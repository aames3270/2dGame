using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to start screen 
    public GameObject startScreen; 
    // Flag to check if game has started
    private bool gameStarted = false; 
    // Called when script first runs
    void Start()
    {
        // Start screen... "Spacebar"
        startScreen.SetActive(true);
        // Pause game at start
        Time.timeScale = 0; 
    }

    void Update()
    {
        // Check if game hasnt started yet... "Did player press space bar?"
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
    // Method to start game
    public void StartGame()
    {
        // Game has started
        gameStarted = true; 
        // Hide start screen
        startScreen.SetActive(false); 
        // Resume game
        Time.timeScale = 1; 
    }
    // Quit game..
    public void QuitGame()
    {
        Application.Quit();
    }
}


