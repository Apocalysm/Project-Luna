using UnityEngine;
using System.Collections;

public class FindNPC : MonoBehaviour
{
    private Dialogue dialogue;
    private DialogueManager dialoguemanager;
    private DialogueTrigger dialoguetrigger;

    void OnCollisionEnter (Collision other)
    {
        GameObject.FindGameObjectWithTag("NPC");
        if (dialoguemanager.dialoguename == Farmer) 
        {
            
        }
    }
}

       