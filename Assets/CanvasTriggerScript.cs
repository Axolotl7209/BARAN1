using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{
    public GameObject instructionCanvas; // Reference to the Canvas GameObject

    private void Start()
    {
        instructionCanvas.SetActive(false); // Hide the Canvas at the start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the object entering the trigger is the Player
        {
            instructionCanvas.SetActive(true); // Show the Canvas
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the object exiting the trigger is the Player
        {
            instructionCanvas.SetActive(false); // Hide the Canvas
        }
    }
}