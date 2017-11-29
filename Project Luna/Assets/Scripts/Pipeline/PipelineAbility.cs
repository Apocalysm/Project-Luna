using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PipeLineValue 
{
    [HideInInspector]
    public bool owned = false;
    public string quest;
    public KeyCode key;

    public Ability ability;
}

public class PipelineAbility : MonoBehaviour
{
    //Dictionary<KeyCode, PipeLineValue> values = new Dictionary<KeyCode, PipeLineValue>();
    public PipeLineValue[] value;


    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {	
        if (Input.GetKeyDown(value[0].key))
        {
            value[0].ability.Initialize(gameObject);
        }
            
    }
}
