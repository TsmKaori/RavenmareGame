using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Image LokiPicture;



    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //nameText = GetComponent<TMP_Text>();

        nameText.text = dialogue.name;
        sentences.Clear();


        Debug.Log("wee");
        if((dialogue.name).Equals("Loki"))    //Check which character is speaking and activate
        {
            LokiPicture.gameObject.SetActive(true);
        }else if((dialogue.name).Equals(""))
        {

        }
        else
        {
            //LokiPicture.enabled = true;

        }

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
        //dialogueText = GetComponent<TMP_Text>();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        LokiPicture.enabled = false;
        //Set Dialogue box inactive here
    }
}
