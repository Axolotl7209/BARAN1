using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    public float jumpForce = 10f; // Force applied when the player jumps
    public int maxHealth = 1; // Maximum health of the player
    private int currentHealth; // Current health of the player
    private bool isGrounded; // Check if the player is on the ground
    private Rigidbody2D rb; // Rigidbody2D component reference
    private Animator animator; // Animator component reference
    private Vector2 spawnPoint; // Spawn point for respawning

    // Animator parameters
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsFalling = Animator.StringToHash("isFalling");

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
        currentHealth = maxHealth; // Set current health to max health
        spawnPoint = transform.position; // Set spawn point to current position
    }

    void Update()
    {
        if (currentHealth > 0) // Only allow movement and jumping if alive
        {
            Move(); // Call the Move function each frame
            Jump(); // Call the Jump function each frame
            UpdateAnimation(); // Update animation states
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Set the velocity of the player

        // Rotate the character based on movement direction
        if (moveInput > 0) // Moving right
        {
            transform.localScale = new Vector3(2f, 2f, 0f); // Face right
        }
        else if (moveInput < 0) // Moving left
        {
            transform.localScale = new Vector3(-2f, 2f, 0f); // Face left
        }
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) // Check if the player is grounded and the jump button is pressed
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Apply jump force
        }
    }

    private void UpdateAnimation()
    {
        // Set animator parameters based on movement and jumping state
        animator.SetBool(IsRunning, Mathf.Abs(rb.velocity.x) > 0.1f); // Running if velocity on x is greater than a small threshold
        animator.SetBool(IsJumping, !isGrounded && rb.velocity.y > 0); // Jumping if not grounded and moving up
        animator.SetBool(IsFalling, rb.velocity.y < 0 && !isGrounded); // Falling if moving down and not grounded

        if (isGrounded && rb.velocity.y == 0)
        {
            animator.SetBool(IsJumping, false); // Reset jump animation when grounded
            animator.SetBool(IsFalling, false); // Reset fall animation when grounded
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if the player has collided with the ground
        {
            isGrounded = true; // Set isGrounded to true
        }

        if (collision.gameObject.CompareTag("Dangerous")) // Check if the player has collided with a dangerous object
        {
            TakeDamage(); // Call the TakeDamage method
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if the player has exited collision with the ground
        {
            isGrounded = false; // Set isGrounded to false
        }
    }

    private void TakeDamage()
    {
        currentHealth--; // Decrease health by 1

        if (currentHealth <= 0) // Check if the player is dead
        {
            Respawn(); // Call the Respawn method
        }
    }

    private void Respawn()
    {
        transform.position = spawnPoint; // Reset position to spawn point
        currentHealth = maxHealth; // Reset health to max health
    }
}
