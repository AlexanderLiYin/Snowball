using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool inRange = false;
    public Dialogue dialogue;
    public GameObject UI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inRange)
            TriggerDialogue();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inRange = false;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
