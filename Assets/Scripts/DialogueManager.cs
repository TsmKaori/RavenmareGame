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

    public bool dialogueActive = false; 

    private Queue<string> words;
    // Start is called before the first frame update
    void Start()
    {
        words = new Queue<string>();
        dialogList = new List<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void iniateDial (List<Dialogue> dial)
    {
        dialogueActive = true;
        dialogueObject.SetActive(true);

        dialogueCount = dial.Count;
        i = 0;
        currentpic = null;
        dialogList = dial;

        nameText.text = dial[i].name;
        words.Clear();


        if ((dial[i].name).Equals("Loki"))    //Check which character is speaking and activate
        {
            if (currentpic != null)
            {
                currentpic.gameObject.SetActive(false);
            }
            LokiPicture.gameObject.SetActive(true);
            currentpic = LokiPicture;
        }
        else if ((dial[i].name).Equals("Toji"))
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

        foreach (string sentence in dial[i].sentences)
        {
            words.Enqueue(sentence);
        }

        nextLine();
    }

    public void nextLine()
    {
        if (i < dialogueCount && words.Count == 0) //To next thing on the dialogue list or next person
        {
            endDial();
            i++;
            if(i >= dialogueCount)
            {
                if (currentpic != null)
                {
                    currentpic.gameObject.SetActive(false);
                }
                dialogueObject.SetActive(false);
                dialogueActive = false;
                return;
            }
            foreach (string sent in dialogList[i].sentences)
            {
                words.Enqueue(sent);
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

        Debug.Log(words.Count);


        string line = words.Dequeue();
        //dialogueText = GetComponent<TMP_Text>();
        dialogueText.text = line;
    }

    public void endDial()
    {
        //LokiPicture.enabled = false;
        //Set Dialogue box inactive here
    }

    public void closeDialogue(GameObject dialogue) {
        dialogue.SetActive(false);
    }
}
