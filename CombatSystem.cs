using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public float leftClickDamage = 10f; // Damage dealt by a left click attack
    public float rightClickDamage = 20f; // Damage dealt by a right click attack
    public float specialAttackDamage = 30f; // Damage dealt by a special attack
    public float ultimateAttackDamage = 50f; // Damage dealt by an ultimate attack
    public float attackCooldown = 0.5f; // Time between attacks
    public float specialAttackCooldown = 10f; // Time between special attacks
    public float ultimateAttackCooldown = 15f; // Time between ultimate attacks
    public GameObject leftClickAttackPrefab; // Prefab for the left click attack effect
    public GameObject rightClickAttackPrefab; // Prefab for the right click attack effect
    public GameObject specialAttackPrefab; // Prefab for the special attack effect
    public GameObject ultimateAttackPrefab; // Prefab for the ultimate attack effect
    public LayerMask attackLayers; // Layers that can be attacked

    private float attackTimer = 0f; // Timer for the attack cooldown
    private float specialAttackTimer = 0f; // Timer for the special attack cooldown
    private float ultimateAttackTimer = 0f; // Timer for the ultimate attack cooldown
    private Animator animator; // Reference to the character's animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the character's animator component
    }

    void Update()
    {
        // Decrement the attack timer
        attackTimer -= Time.deltaTime;
        specialAttackTimer -= Time.deltaTime;
        ultimateAttackTimer -= Time.deltaTime;

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the attack timer is less than or equal to zero
            if (attackTimer <= 0f)
            {
                // Reset the attack timer
                attackTimer = attackCooldown;

                // Attack with the left click
                AttackLeftClick();
            }
        }

        // Check if the right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Check if the attack timer is less than or equal to zero
            if (attackTimer <= 0f)
            {
                // Reset the attack timer
                attackTimer = attackCooldown;

                // Attack with the right click
                AttackRightClick();
            }
        }

        // Check if the special attack key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Check if the special attack timer is less than or equal to zero
            if (specialAttackTimer <= 0f)
            {
                // Reset the special attack timer
                specialAttackTimer = specialAttackCooldown;

                // Perform the special attack
                SpecialAttack();
            }
        }

        // Check if the ultimate attack key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the ultimate attack timer is less than or equal to zero
            if (ultimateAttackTimer <= 0f)
            {
