using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]



public class PipeLineValue 
{

    public string questName;
    public KeyCode key;
    public Image abilitySprite;
    public Image overlaySprite;
    public Ability ability;
    private float timer = 0;

    public void BuyAbility()
    {
        //Check if the player have enough supplies to buy the ability 
        if(ability.supplies >= 10)
        {
            ability.owned = true;
            overlaySprite.fillAmount = 0;
        }
    }

    public void Update()
    {
        if (timer >= ability.coolDown)
        {
            timer = 0;
            ability.canUse = true;
        }
        else
        {
            overlaySprite.fillAmount -= 1.0f / ability.coolDown * Time.deltaTime;
            timer += Time.deltaTime;
        }
    } 
}

public class PipelineAbility : MonoBehaviour
{
    public enum Abilities { STOPFOLLOW = 0, HIDE = 1 }
    public PipeLineValue[] value;

    // Use this for initialization
    void Awake ()
    {
        for(int i = 0; i < value.Length; i ++)
        {
            value[i].ability.canUse = true;
            if (value[i].ability.owned == true)
                value[i].overlaySprite.fillAmount = 0;
        }
        
    }

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i< value.Length; i++)
        {
            //Check if the specific ability key is pressed
            if (Input.GetKeyDown(value[i].key) && value[i].ability.canUse == true && value[i].ability.owned == true)
            {
                //Use the specific ability
                value[i].ability.Initialize(gameObject);
                value[i].overlaySprite.fillAmount = 1;
            }

            if(value[i].ability.canUse == false)
            {
                value[i].Update();
            }
        }
    }

    public void BuyAbility(int index)
    {
        value[index].BuyAbility();
    }
}
