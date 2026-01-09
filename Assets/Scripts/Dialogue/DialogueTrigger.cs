using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogueLines;

    private bool playerInRange;
    private PlayerPrompt activePlayerPrompt; // Reference to the player's prompt script

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!DialogueManager.Instance.IsDialogueActive())
            {
                DialogueManager.Instance.StartDialogue(dialogueLines);
                
                // Optional: Hide the "E to Talk" prompt immediately when talking starts
                if (activePlayerPrompt != null)
                    activePlayerPrompt.HidePrompt();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            // Try to find the prompt script on the player and show it
            activePlayerPrompt = other.GetComponent<PlayerPrompt>();
            if (activePlayerPrompt != null)
            {
                activePlayerPrompt.ShowPrompt();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            // Hide the prompt when leaving
            if (activePlayerPrompt != null)
            {
                activePlayerPrompt.HidePrompt();
                activePlayerPrompt = null;
            }
            
            // Safe guard: Close dialogue if player runs away
            if (DialogueManager.Instance.IsDialogueActive())
            {
                DialogueManager.Instance.EndDialogue(); // Or CloseDialogue() depending on your Manager script name
            }
        }
    }
}