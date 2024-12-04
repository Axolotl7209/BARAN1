using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Vector2 lastCheckpoint; // Store the last checkpoint position
    private static bool checkpointActive; // Check if the checkpoint is active

    private void Start()
    {
        lastCheckpoint = transform.position; // Set the initial checkpoint position to this object's position
        checkpointActive = false; // Initially, no checkpoint is active
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player has entered the checkpoint
        {
            lastCheckpoint = transform.position; // Update the last checkpoint position
            checkpointActive = true; // Mark the checkpoint as active
            Debug.Log("Checkpoint activated!"); // Debug message for checkpoint activation
        }
    }

    public static Vector2 GetLastCheckpoint()
    {
        if (checkpointActive)
        {
            return lastCheckpoint; // Return the last checkpoint position if active
        }
        return Vector2.zero; // Return zero if no checkpoint is active
    }
}