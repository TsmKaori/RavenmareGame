using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        Debug.Log("start");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
