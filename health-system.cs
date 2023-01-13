using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f; // The maximum health the character can have
    public float currentHealth; // The character's current health
    public bool isInvincible = false; // If the character is invincible and can't take damage
    public GameObject deathEffect; // Prefab for the death effect
    public GameObject damageEffect; // Prefab for the damage effect
    public Slider healthBar; // Reference to the health bar UI element

    private bool isDead = false; // If the character is dead

    void Start()
    {
        currentHealth = maxHealth; // Set the current health to the max health
    }

    void Update()
    {
        // Update the health bar's value
        healthBar.value = currentHealth / maxHealth;

        // Check if the character is dead
        if (isDead)
        {
            // Do something when the character dies (e.g. play a death animation)
            // ...
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            // Decrement the current health by the damage taken
            currentHealth -= damage;

            // Instantiate the damage effect
            Instantiate(damageEffect, transform.position, Quaternion.identity);

            // Check if the current health is less than or equal to zero
            if (currentHealth <= 0f)
            {
                Die();
            }
        }
    }

    public void Heal(float healAmount)
    {
        // Increment the current health by the heal amount
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
    }

    public void Die()
    {
        // Set the isDead flag to true
        isDead = true;

        // Instantiate the death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        // Disable the character's renderer and collider
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        // Send a message to the GameManager to handle the
