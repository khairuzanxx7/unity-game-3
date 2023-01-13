using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    public int currentLevel = 1; // The current level
    public int maxLevels = 5; // The maximum number of levels in the game
    public string levelPrefix = "Level"; // The prefix for the level scenes

    public int playerHealth = 100; // The player's current health
    public int playerDamage = 10; // The player's current damage
    public int playerHealthIncrement = 20; // The amount to increase the player's health
    public int playerDamageIncrement = 5; // The amount to increase the player's damage

    void Start()
    {
        // Load the first level
        SceneManager.LoadScene(levelPrefix + currentLevel);
    }

    public void NextLevel()
    {
        // Check if the current level is less than the maximum number of levels
        if (currentLevel < maxLevels)
        {
            // Increment the current level
            currentLevel++;

            // Load the next level
            SceneManager.LoadScene(levelPrefix + currentLevel);
        }
        else
        {
            // Do something when all levels are completed (e.g. display a "game over" screen)
            // ...
        }
    }

    public void RestartLevel()
    {
        // Load the current level
        SceneManager.LoadScene(levelPrefix + currentLevel);
    }

    public void IncreasePlayerHealth()
    {
        playerHealth += playerHealthIncrement;
    }

    public void DecreasePlayerHealth(int damage)
    {
        playerHealth -= damage;
    }

    public void IncreasePlayerDamage()
    {
        playerDamage += playerDamageIncrement;
    }

    public void DecreasePlayerDamage(int amount)
    {
        playerDamage -= amount;
    }

    public void AddItemToInventory(string item)
    {
        // Add an item to the player's inventory
    }

    public void RemoveItemFromInventory(string item)
    {
        // Remove an item from the player's inventory
    }

    public void UnlockAbility(string ability)
    {
        // Unlock a new ability for the player
    }

    public void SetCheckpoint(Vector3 checkpoint)
    {
        // Set a new checkpoint for the player to respawn at
    }
}
