using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel; // Panel that contains the dialog text
    public TMP_Text dialogText; // Text component to display the dialog
    private bool isPlayerNear = false; // Check if player is near the NPC

    void Start()
    {
        dialogPanel.SetActive(false); // Hide dialog panel at the start
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) // Check if player is near and presses E
        {
            ToggleDialog(); // Toggle dialog visibility
        }
    }

    private void ToggleDialog()
    {
        dialogPanel.SetActive(!dialogPanel.activeSelf); // Show or hide the dialog panel
    }

    public void SetDialogText(string text)
    {
        dialogText.text = text; // Set the dialog text
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player enters the trigger
        {
            isPlayerNear = true; // Set player near flag to true
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player exits the trigger
        {
            isPlayerNear = false; // Set player near flag to false
            dialogPanel.SetActive(false); // Hide dialog panel when player leaves
        }
    }
}