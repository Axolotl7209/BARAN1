using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogManager dialogManager; // Reference to DialogManager
    public string dialogText = "Hello! How can I help you?"; // Dialog text for the NPC

    private void Start()
    {
        if (dialogManager == null)
        {
            dialogManager = FindObjectOfType<DialogManager>(); // Find DialogManager in the scene
        }
    }

    private void Update()
    {
        if (dialogManager.dialogPanel.activeSelf) // If dialog is active
        {
            dialogManager.SetDialogText(dialogText); // Set the dialog text
        }
    }
}