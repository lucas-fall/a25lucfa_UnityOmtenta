using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI")]
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    private Queue<string> lines = new Queue<string>();
    private bool dialogueActive = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // FORCE TMP to initialize on main thread
        if (dialogueText != null)
        {
            dialogueText.text = "";
        }

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextLine();
        }
    }

    public void StartDialogue(string[] dialogueLines)
    {
        dialogueActive = true;
        dialogueBox.SetActive(true);

        lines.Clear();

        foreach (string line in dialogueLines)
            lines.Enqueue(line);

        DisplayNextLine();
    }

    void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = lines.Dequeue();
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }
}