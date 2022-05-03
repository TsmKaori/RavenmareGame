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
        FindObjectOfType<DialogueManager>().iniateDial(firstTrapSceneDialogue);
    }
    public void TriggerSecondCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(secondTrapSceneDialogue);
    }
    public void TriggerThirdCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(thirdTrapSceneDialogue);
    }

    public void TriggerFourthCutSceneDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(fourthTrapSceneDialogue);
    }

    public void triggerFirstWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(firstWaveDialogue);
    }

    public void triggerSecondWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(secondWaveDialogue);
    }

    public void triggerThirdWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(thirdWaveDialogue);
    }

    public void triggerFourthWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(fourthWaveDialogue);
    }

    public void triggerFifthWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(fifthWaveDialogue);
    }

    public void triggerBossWaveDialogue()
    {
        FindObjectOfType<DialogueManager>().iniateDial(bossDialogue);
    }
}
