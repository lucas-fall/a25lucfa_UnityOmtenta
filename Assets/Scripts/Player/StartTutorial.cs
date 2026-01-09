using UnityEngine;

public class StartTutorial : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject tutorialTextObject; // Assign your "WASD to Move" text here

    private bool hasMoved = false;

    void Start()
    {
        // Ensure the text is visible when the game begins
        if (tutorialTextObject != null)
            tutorialTextObject.SetActive(true);
    }

    void Update()
    {
        // 1. If the player has already moved, stop running this code to save performance.
        if (hasMoved) return;

        // 2. Check for any movement input.
        // We use GetAxisRaw because it detects the button press immediately.
        // (GetAxis without 'Raw' has a slight delay for smoothing).
        float horizontal = Input.GetAxisRaw("Horizontal"); // A, D, Left, Right
        float vertical = Input.GetAxisRaw("Vertical");     // W, S, Up, Down

        // 3. If either value is NOT zero, the player is pressing a button.
        if (horizontal != 0 || vertical != 0)
        {
            HidePrompt();
        }
    }

    void HidePrompt()
    {
        if (tutorialTextObject != null)
        {
            tutorialTextObject.SetActive(false);
        }
        
        hasMoved = true;
    }
}