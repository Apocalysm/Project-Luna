using UnityEngine;
using System.Collections;

public class FindNPC : MonoBehaviour {
    public Dialogue dialogue;

    void update () {
        RaycastHit hit;
        float Distance;
        GameObject.FindWithTag("NPC");
 

        //Debug raycast
         Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
         Debug.DrawRay(transform.position, forward, Color.green);

        if(Physics.Raycast(transform.position, (forward), out hit)){
            Distance = hit.distance;
            print(Distance + " " + hit.collider.gameObject.tag);
        }
            if(gameObject.tag == "NPC" & hit.distance < 1)
            {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        }
}