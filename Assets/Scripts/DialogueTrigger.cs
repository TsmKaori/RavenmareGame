using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> trapSceneDialogue = new List<Dialogue>();
    public List<Dialogue> firstWaveDialogue = new List<Dialogue>();
    public List<Dialogue> secondWaveDialogue = new List<Dialogue>();
    public List<Dialogue> thirdWaveDialogue = new List<Dialogue>();
    public List<Dialogue> fourthWaveDialogue = new List<Dialogue>();
    public List<Dialogue> fifthWaveDialogue = new List<Dialogue>();
    //public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(trapSceneDialogue);
    }

    public void triggerFirstWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(firstWaveDialogue);
    }

    public void triggerSecondWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(secondWaveDialogue);
    }

    public void triggerThirdWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(thirdWaveDialogue);
    }

    public void triggerFourthWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(fourthWaveDialogue);
    }

    public void triggerFifthWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(fifthWaveDialogue);
    }
}
