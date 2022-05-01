using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrappedCutSceneManager : MonoBehaviour
{
    public DialogueManager dialogue;
    public DialogueTrigger triggerDialogue;
    private int currentDialogue = -1;

    public GameObject firstImage;
    public GameObject secondImage;
    public GameObject thirdImage;
    public GameObject fourthImage;
    public GameObject fifthImage;

    public bool currDelay = false;

    [SerializeField]
    private Animator fadeAnimator;
    [SerializeField]
    private GameObject fade;
    // Start is called before the first frame update
    void Start()
    {
        //Pull up initial dialogue
        StartCoroutine(firstDialogueDelay());
    }

    // Update is called once per frame
    void Update()
    {
        //update image here and check on dialogue
        if(currentDialogue == 0 && !dialogue.dialogueActive && !currDelay)
        {
            //Go to next picture
            secondImage.SetActive(false);
            thirdImage.SetActive(true);
            StartCoroutine(delaySecondDialogue());
        }
        else if(currentDialogue == 1 && !dialogue.dialogueActive && !currDelay)
        {
            StartCoroutine(delaythirdDialogue());
            //triggerDialogue.TriggerThirdCutSceneDialogue();
            //currentDialogue++;
        }else if (currentDialogue == 2 && !dialogue.dialogueActive && !currDelay)
        {
            StartCoroutine(delayfourthDialogue());
            //triggerDialogue.TriggerFourthCutSceneDialogue();
            //currentDialogue++;
        }
        else if (currentDialogue == 3 && !dialogue.dialogueActive && !currDelay)
        {
            StartCoroutine(transitionToNextScene());
        }
        
    }

    IEnumerator firstDialogueDelay()
    {
        currDelay = true;
        yield return new WaitForSeconds(3f);
        currDelay = false;
        firstImage.SetActive(false);
        secondImage.SetActive(true);
        triggerDialogue.TriggerFirstCutSceneDialogue();
        currentDialogue++;
    }

    IEnumerator delaySecondDialogue()
    {
        currDelay = true;
        yield return new WaitForSeconds(1f);
        currDelay = false;
        triggerDialogue.TriggerSecondCutSceneDialogue();
        currentDialogue++;
    }

    IEnumerator delaythirdDialogue()
    {
        currDelay = true;
        yield return new WaitForSeconds(1f);
        currDelay = false;
        triggerDialogue.TriggerThirdCutSceneDialogue();
        currentDialogue++;
    }

    IEnumerator delayfourthDialogue()
    {
        currDelay = true;
        yield return new WaitForSeconds(1f);
        currDelay = false;
        triggerDialogue.TriggerFourthCutSceneDialogue();
        currentDialogue++;
    }

    IEnumerator transitionToNextScene()
    {
        fade.SetActive(true);
        fadeAnimator.SetTrigger("Ends");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

}
