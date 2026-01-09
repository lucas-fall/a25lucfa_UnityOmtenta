using UnityEngine;

public class PlayerPrompt : MonoBehaviour
{
    public GameObject promptObject; // Drag the PromptCanvas or Text object here

    void Start()
    {
        // Hide it by default
        if (promptObject != null)
            promptObject.SetActive(false);
    }

    public void ShowPrompt()
    {
        if (promptObject != null)
            promptObject.SetActive(true);
    }

    public void HidePrompt()
    {
        if (promptObject != null)
            promptObject.SetActive(false);
    }
}