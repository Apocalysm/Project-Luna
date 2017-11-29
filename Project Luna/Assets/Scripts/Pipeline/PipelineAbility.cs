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
    Dictionary<KeyCode, PipeLineValue> dictionary = new Dictionary<KeyCode, PipeLineValue>();

    // Use this for initialization
    void Start ()
    {
        dictionary.Add(KeyCode.R, value[0]);
	}
	
	// Update is called once per frame
	void Update ()
    {
            dictionary[Event.current.keyCode].ability.Initialize(gameObject);

        //for(int i = 0; i < value.Length; i ++ )
        //{
        //    if(Input.GetKeyDown(value[i].key))
        //    {
        //        value[i].ability.Initialize(gameObject);
        //    }
        //}
            
    }
}
