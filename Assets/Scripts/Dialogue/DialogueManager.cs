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
    }

    void Start()
    {
        // FIX: Only hide the UI if the dialogue hasn't already started.
        // This prevents the Manager from closing the box if an NPC opened it 
        // in the exact same frame.
        if (!dialogueActive)
        {
            if (dialogueText != null)
                dialogueText.text = "";

            if (dialogueBox != null)
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
        
        if (dialogueBox != null)
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

        if (dialogueText != null)
            dialogueText.text = lines.Dequeue();
    }

   public void EndDialogue()
    {
        dialogueActive = false;
        
        if (dialogueBox != null)
            dialogueBox.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }
}