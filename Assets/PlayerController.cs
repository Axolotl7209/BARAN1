using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    public float jumpForce = 10f; // Force applied when the player jumps
    private bool isGrounded; // Check if the player is on the ground
    private Rigidbody2D rb; // Rigidbody2D component reference

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        Move(); // Call the Move function each frame
        Jump(); // Call the Jump function each frame
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow)
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Set the velocity of the player
    }

    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) // Check if the player is grounded and the jump button is pressed
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Apply jump force
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if the player has collided with the ground
        {
            isGrounded = true; // Set isGrounded to true
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if the player has exited collision with the ground
        {
            isGrounded = false; // Set isGrounded to false
        }
    }
}

