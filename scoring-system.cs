using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public int currentScore; // The current score
    public Text scoreText; // Reference to the score text UI element
    public int bonusPoints; // Bonus points for completing certain tasks
    public int penaltyPoints; // Penalty points for failing certain tasks
    public int killPoints; // Points for killing enemies
    public int collectiblePoints; // Points for collecting certain items
    public int levelCompletePoints; // Points for completing a level
    public int challengeCompletePoints; // Points for completing a challenge
    public int highScore; // The highest score achieved
    public Text highScoreText; // Reference to the high score text UI element

    void Start()
    {
        currentScore = 0; // Initialize the score to 0
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Get the high score from PlayerPrefs
        highScoreText.text = "High Score: " + highScore; // Update the high score text
    }

    void Update()
    {
        scoreText.text = "Score: " + currentScore; // Update the score text
    }

    public void AddPoints(int points)
    {
        currentScore += points; // Add points to the score
        CheckHighScore();
    }

    public void RemovePoints(int points)
    {
        currentScore -= points; // Remove points from the score
    }

    public void AddBonusPoints()
    {
        currentScore += bonusPoints; // Add bonus points to the score
        CheckHighScore();
    }

    public void AddPenaltyPoints()
    {
        currentScore -= penaltyPoints; // Add penalty points to the score
    }

    public void AddKillPoints()
    {
        currentScore += killPoints; // Add kill points to the score
        CheckHighScore();
    }

    public void AddCollectiblePoints()
    {
        currentScore += collectiblePoints; // Add collectible points to the score
        CheckHighScore();
    }

    public void AddLevelCompletePoints()
    {
        currentScore += levelCompletePoints; // Add level complete points to the score
        CheckHighScore
