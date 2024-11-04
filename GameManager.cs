using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScoreText;
    public float score = 0f;
    private bool gameOver = false;
    private int highScore = 0;
    private AudioSource audioSource;

    public AudioClip highScoreSound;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // 0 is the default value if no high score is saved
        highScoreText.text = "High Score: " + highScore.ToString();

        scoreText.text = "Score: ";
        gameOverText.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameOver)
        {
            // Increase the score over time
            score += Time.deltaTime;
            int displayScore = Mathf.FloorToInt(score);
            scoreText.text = " " + displayScore;
        }

        // Press "R" to restart the game if it's over
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    // Called when the player is hit
    public void EndGame()
    {
        gameOver = true;

        int finalScore = Mathf.FloorToInt(score);
        if (finalScore > highScore)
        {
            highScore = finalScore;
            highScoreText.text = "High Score: " + highScore.ToString();

            // Save the new high score using PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Make sure PlayerPrefs are saved immediately
            if (highScoreSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(highScoreSound);
            }
        }

        // Delay showing the Game Over message
        Invoke("ShowGameOver", 1.5f); // Adjust delay time as needed
    }

    void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    // Restart the game by reloading the scene
    void RestartGame()
    {
        Time.timeScale = 1; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
