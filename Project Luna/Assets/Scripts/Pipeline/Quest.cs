using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Quest : MonoBehaviour {

    protected bool questDone = false;
    protected bool haveQuest = false;

    public delegate bool QuestStuff();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    //Return if the quest what the quest state is
    public bool QuestDone()
    {
        return questDone;
    }

    public virtual void QuestFunction()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
