using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrappedCutSceneManager : MonoBehaviour
{
    public DialogueManager dialogue;
    public DialogueTrigger triggerDialogue;
    private int currentDialogue = -1;

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
        if(currentDialogue == 0 && !dialogue.dialogueActive)
        {
            //Go to next picture
            triggerDialogue.TriggerSecondCutSceneDialogue();
            currentDialogue++;
        }
        else if(currentDialogue == 1 && !dialogue.dialogueActive)
        {
            triggerDialogue.TriggerThirdCutSceneDialogue();
            currentDialogue++;
        }else if (currentDialogue == 2 && !dialogue.dialogueActive)
        {
            StartCoroutine(transitionToNextScene());
        }
        
    }

    IEnumerator firstDialogueDelay()
    {
        yield return new WaitForSeconds(3f);
        triggerDialogue.TriggerFirstCutSceneDialogue();
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
