using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character should move
    public float rotateSpeed = 5f; // The speed at which the character should rotate
    public float jumpForce = 5f; // The force at which the character should jump
    public float gravity = 9.8f; // The force of gravity
    public float groundCheckDistance = 0.1f; // The distance at which to check if the character is on the ground
    public LayerMask groundLayers; // The layers that are considered "ground" for the character

    private bool isJumping = false; // Whether or not the character is currently jumping
    private bool isOnGround = true; // Whether or not the character is currently on the ground
    private Rigidbody rb; // Reference to the character's rigidbody component
    private Vector3 moveDirection = Vector3.zero; // The direction in which the character should move
    private Vector3 rotateDirection = Vector3.zero; // The direction in which the character should rotate

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the character's rigidbody component
    }

    void Update()
    {
        // Get input from the horizontal and vertical axes (usually the left stick on a controller or the W, A, S, D keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Set the move direction based on the input
        moveDirection = new Vector3(moveX, 0f, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        
        // check if w,a,s,d are pressed
        if(Input.GetKey(KeyCode.W))
            moveDirection += transform.forward;
        if(Input.GetKey(KeyCode.S))
            moveDirection -= transform.forward;
        if(Input.GetKey(KeyCode.A))
            moveDirection -= transform.right;
        if(Input.GetKey(KeyCode.D))
            moveDirection += transform.right;

        // Get input from the mouse to rotate the character
        float rotateX = Input.GetAxis("Mouse X");
        float rotateY = Input.GetAxis("Mouse Y");

        // Set the rotate direction based on the input
        rotateDirection = new Vector3(rotateX, rotateY, 0f);
        rotateDirection *= rotateSpeed;

        // Check if the jump button is pressed (usually the spacebar or the 'A' button on a controller)
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        // Check if the character is on the ground
        isOnGround = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayers);

        // Add gravity to the character
        rb.AddForce(new Vector3(0f, -gravity * rb.mass, 0f
