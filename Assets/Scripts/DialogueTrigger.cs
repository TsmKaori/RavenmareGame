using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> firstTrapSceneDialogue = new List<Dialogue>();
    public List<Dialogue> secondTrapSceneDialogue = new List<Dialogue>();
    public List<Dialogue> thirdTrapSceneDialogue = new List<Dialogue>();
    public List<Dialogue> fourthTrapSceneDialogue = new List<Dialogue>();

    public List<Dialogue> firstWaveDialogue = new List<Dialogue>();
    public List<Dialogue> secondWaveDialogue = new List<Dialogue>();
    public List<Dialogue> thirdWaveDialogue = new List<Dialogue>();
    public List<Dialogue> fourthWaveDialogue = new List<Dialogue>();
    public List<Dialogue> fifthWaveDialogue = new List<Dialogue>();
    public List<Dialogue> bossDialogue = new List<Dialogue>();
    //public Dialogue dialogue;

    public void TriggerFirstCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(firstTrapSceneDialogue);
    }
    public void TriggerSecondCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(secondTrapSceneDialogue);
    }
    public void TriggerThirdCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(thirdTrapSceneDialogue);
    }

    public void TriggerFourthCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(fourthTrapSceneDialogue);
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

    public void triggerBossWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(bossDialogue);
    }
}
