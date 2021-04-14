using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private bool IsInDialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting conversation with " + dialogue.name);
        IsInDialogue = true;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("ending conversation");
        IsInDialogue = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsInDialogue == true)
        {
            DisplayNextSentence();
        }
    }
    //this is where I got most of this dialogue stuff from https://www.youtube.com/watch?v=_nRzoTzeyxU
}
