using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PipeLineValue 
{
    [HideInInspector]
    public bool owned = false;
    public string questName;
    public KeyCode key;
    public Image abilitySprite;
    public Image darkenabilitySprite;
    public Ability ability;
    public Button buyButton;

    private Quest quest;
    private GameObject questQiver;
    private float timer = 0;


    public void BuyAbility()
    {
        //Check if the player have enough supplies to buy the ability 
        if(ability.supplies >= 10)
        {
            owned = true;
            darkenabilitySprite.fillAmount = 0;
        }
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
            darkenabilitySprite.fillAmount -= 1.0f / ability.coolDown * Time.deltaTime;
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
        
    }

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i< value.Length; i++)
        {
            //Check if the specific ability key is pressed
            if (Input.GetKeyDown(value[i].key) && value[i].ability.canUse == true)
            {
                //Use the specific ability
                value[i].ability.Initialize(gameObject);
                value[i].darkenabilitySprite.fillAmount = 1;
            }

            if(value[i].ability.canUse == false)
            {
                value[i].Update();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
            value[0].BuyAbility();
    }
}
