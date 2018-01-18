using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PipeLineValue 
{
    public enum TypeAbility { COMMAND = 0, PASSIVE = 1, DEFENCE = 2 };

    public string abilityName; 
    public TypeAbility type;
    public KeyCode key;
    public Image abilitySprite;
    public Image overlaySprite;
    public Ability ability;
    public Button button;
    private float timer = 0;

    //Function for buying the ability
    public void BuyAbility()
    {
        //Check if the player have enough supplies to buy the ability 
        if(ability.supplies >= 10)
        {
            button.interactable = false;
            ability.owned = true;
            button.GetComponentInChildren<Text>().text = "Owned";
            overlaySprite.fillAmount = 0;
        }
    }

    //A update function for the ability
    public void Update()
    {
        //Checks if the timer is equal or more then the cooldown
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
    public PipeLineValue[] value;
    [HideInInspector]
    public GameObject luna;
    public Transform[] contentPanel;
    public Button button;

    // Use this for initialization
    void Start ()
    {
        for(int i = 0; i < value.Length; i ++)
        {
            //value[i].ability.canUse = true;
            //Check if player ownes the ability
            if (value[i].ability.owned == true)
                value[i].overlaySprite.fillAmount = 0;       
        }

        AddButtons();

        luna = GameObject.FindGameObjectWithTag("Luna");
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
                value[i].ability.Initialize(luna,gameObject);
                value[i].overlaySprite.fillAmount = 1;
                //value[i].ability.animation.Play();
            }

            if(value[i].ability.canUse == false && !value[i].ability.passive)
            {
                value[i].Update();
            }
        }
    }

    //Will buy the ability when the button is pressed
    public void BuyAbility(int index)
    {
        value[index].BuyAbility();
    }

    //Adds the button to the UI
    private void AddButtons()
    {
        for(int i = 0; i < value.Length; i++)
        {
            //Check with planel it belongs too
            for (int j = 0; j < contentPanel.Length; j++)
            {
                if ((int)value[i].type == j)
                    value[i].button = Instantiate(button, contentPanel[j]);
            }

            //Check if ther player ownes the ability
            if(value[i].ability.owned == true)
            {
                //Set the button to not interactable
                value[i].button.interactable = false;
                value[i].button.GetComponentInChildren<Text>().text = "Owned";
                continue;
            }
            
            //Set the text to the right price.
            value[i].button.GetComponentInChildren<Text>().text  = value[i].ability.supplies.ToString();
            int index = i;
            value[i].button.onClick.AddListener(() => BuyAbility(index));
        }
    }
}
