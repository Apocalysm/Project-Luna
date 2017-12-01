using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
 

[System.Serializable]
public class PipeLineValue 
{
    [HideInInspector]
    public bool owned = false;
    public string questName;
    public KeyCode key;
    public Sprite abilitySprite;
    public Ability ability;

    private Quest quest;
    private GameObject questQiver;
    private float timer = 0;

    public void SetQuestGiver()
    {
        //Find the quest giver in the scene
        questQiver = GameObject.Find(questName);
        quest = questQiver.GetComponent<Quest>();
    }

    public void Update()
    {
        if (timer >= ability.coolDown)
        {
            timer = 0;
            ability.canUse = true;
            Debug.Log(ability.canUse);
        }
        else
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            Debug.Log(ability.canUse);
        }
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
            //Check if the quest giver is in the scene
            if (GameObject.Find(value[i].questName) == true)
            {
                //Set the quest giver
                value[i].SetQuestGiver();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i< value.Length; i++)
        {
            //Check if the specific ability key is pressed
            if (Input.GetKeyDown(value[i].key))
            {
                //Use the specific ability
                value[i].ability.Initialize(gameObject);
            }

            if(!value[i].ability.canUse)
            {
                value[i].Update();
            }
        }

    }
}
