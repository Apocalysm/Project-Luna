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
    public Text abilityPrice;
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

   public void SetUpButton(Transform panel)
    {
        //button = Instantiate(Button) as GameObject;

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
    public enum TypeAbility { COMMAND = 0, PASSIVE = 1, DEFENCE = 2 };
    public PipeLineValue[] value;
    public Transform[] contentPanel;
    public Button button;

    // Use this for initialization
    void Start ()
    {
        for(int i = 0; i < value.Length; i ++)
        {
            value[i].ability.canUse = true;
            if (value[i].ability.owned == true)
                value[i].overlaySprite.fillAmount = 0;

            int index = i;
            value[i].ability.owned = false;
           
        }

        AddButtons();
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
        Debug.Log(index);
        value[index].BuyAbility();
    }

    private void AddButtons()
    {
        for(int i = 0; i < value.Length; i++)
        {

            //value[i].SetUpButton(contentPanel);
            int index = i;
            for (int j = 0; j < contentPanel.Length; j++)
            {
                if ((int)value[i].type == j)
                    value[i].button = Instantiate(button, contentPanel[j]);
            }

            value[i].button.onClick.AddListener(() => BuyAbility(index));
        }
    }
}
