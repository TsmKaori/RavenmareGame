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
    public Image TojiPicture;

    public GameObject dialogueObject;

    
    int i;
    int dialogueCount;
    List<Dialogue> dialogList;
    Image currentpic;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogList = new List<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue (List<Dialogue> dialogue)
    {
        dialogueObject.SetActive(true);

        dialogueCount = dialogue.Count;
        i = 0;
        currentpic = null;
        dialogList = dialogue;

        nameText.text = dialogue[i].name;
        sentences.Clear();


        if ((dialogue[i].name).Equals("Loki"))    //Check which character is speaking and activate
        {
            if (currentpic != null)
            {
                currentpic.gameObject.SetActive(false);
            }
            LokiPicture.gameObject.SetActive(true);
            currentpic = LokiPicture;
        }
        else if ((dialogue[i].name).Equals("Toji"))
        {
            if (currentpic != null)
            {
                currentpic.gameObject.SetActive(false);
            }
            TojiPicture.gameObject.SetActive(true);
            currentpic = TojiPicture;
        }
        else
        {
            if (currentpic != null)
            {
                currentpic.gameObject.SetActive(false);
            }
        }

        foreach (string sentence in dialogue[i].sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (i < dialogueCount && sentences.Count == 0) //To next thing on the dialogue list or next person
        {
            EndDialogue();
            i++;
            if(i >= dialogueCount)
            {
                if (currentpic != null)
                {
                    currentpic.gameObject.SetActive(false);
                }
                dialogueObject.SetActive(false);
                return;
            }
            foreach (string sentenc in dialogList[i].sentences)
            {
                sentences.Enqueue(sentenc);
            }

            nameText.text = dialogList[i].name;

            if ((dialogList[i].name).Equals("Loki"))    //Check which character is speaking and activate
            {
                if (currentpic != null)
                {
                    currentpic.gameObject.SetActive(false);
                }
                LokiPicture.gameObject.SetActive(true);
                currentpic = LokiPicture;
            }
            else if ((dialogList[i].name).Equals("Toji"))
            {
                if (currentpic != null)
                {
                    currentpic.gameObject.SetActive(false);
                }
                TojiPicture.gameObject.SetActive(true);
                currentpic = TojiPicture;
            }
            else
            {
                if (currentpic != null)
                {
                    currentpic.gameObject.SetActive(false);
                }
            }
        }
        else if (i >= dialogueCount) //End of the whole dialogue
        {
            if (currentpic != null)
            {
                currentpic.gameObject.SetActive(false);
            }
            return;
        }

        Debug.Log(sentences.Count);


        string sentence = sentences.Dequeue();
        //dialogueText = GetComponent<TMP_Text>();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        //LokiPicture.enabled = false;
        //Set Dialogue box inactive here
    }
}
