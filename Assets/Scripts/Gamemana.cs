using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public int score = 0; // Variable to keep track of score
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying score

    void Start()
    {
        UpdateScoreText(); // Initialize the score text at the start
    }

    public void AddScore(int points)
    {
        score += points; // Add points to the score
        UpdateScoreText(); // Update the displayed score
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the score display
    }
}
