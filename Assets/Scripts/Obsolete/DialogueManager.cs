using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    /*
    Queue<string> sentences;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject canvas;
    public GameObject shop;
    SnowPrincess player;
    bool isShop = false;
    bool inDialogue = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>(); // Creates the queue for the text
        player = GameObject.Find("SnowPrincess").GetComponent<SnowPrincess>();
    }

    void Update()
    {
        if (inDialogue && Input.GetButtonDown("Fire1"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue, bool shop)
    {
        isShop = shop;
        inDialogue = true;
        nameText.text = dialogue.name;
        canvas.SetActive(true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        player.canMove = false;
        DisplayNextSentence(); //Displays the first sentence
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            if(!isShop)
            {
                EndDialogue();
                return;
            }
            else
            {
                inDialogue = false;
                canvas.SetActive(false);
                shop.SetActive(true);
                return;
            }
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.05f);
        }
    }

    void EndDialogue()
    {
        inDialogue = false;
        canvas.SetActive(false);
        player.canMove = true;
    }
    */
}
