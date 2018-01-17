using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaScript : MonoBehaviour {

    string floorTag;
    bool activated = false;
    private PipelineAbility pipeline;
    bool owned = false;

    // Use this for initialization
    void Awake ()
    {
        pipeline = GameObject.FindGameObjectWithTag("PlayerParent").GetComponent<PipelineAbility>();
        for (int i = 0; i < pipeline.value.Length; i++)
        {
            if (pipeline.value[i].abilityName == "SilentMove")
            {
                owned = pipeline.value[i].ability.owned;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;   
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            floorTag = hit.collider.tag;
        }

        if(floorTag == "Gravel" && !activated && !owned)
        {
            for(int i = 0; i < pipeline.value.Length; i++)
            {
                if (pipeline.value[i].abilityName == "SilentMove")
                {
                    pipeline.value[i].ability.Initialize(gameObject, null);
                    activated = true;
                }
            }
        }

        else if(floorTag != "Gravel" && activated && !owned)
        {
            for (int i = 0; i < pipeline.value.Length; i++)
            {
                if (pipeline.value[i].abilityName == "SilentMove")
                {
                    pipeline.value[i].ability.Initialize(gameObject, null);
                    activated = false;
                }
            }
        }
           
	}
}
