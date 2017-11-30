using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
 

[System.Serializable]
public class PipeLineValue 
{
    System.Type type;
    [HideInInspector]
    public bool owned = false;
    public string questName;
    public KeyCode key;

    
    public Ability ability;
    private Quest quest;
    private GameObject questQiver;

    public void SetGameObject(GameObject gameObject)
    {
        questQiver = gameObject;
    }

    public void SetQuestGiver()
    {
        type = System.Type.GetType(questName);
        questQiver = GameObject.Find(questName);
        quest = questQiver.GetComponent<Quest>();
        owned =  quest.QuestDone();
        Debug.Log(owned); 
    }    
}

public class PipelineAbility : MonoBehaviour
{
    public PipeLineValue[] value;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < value.Length; i++)
        {
            value[i].SetGameObject(gameObject);
            value[i].SetQuestGiver();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i< value.Length; i++)
        {
            if (Input.GetKeyDown(value[i].key))
            {
                value[i].ability.Initialize(gameObject);
            }
        }

        
    }
}
