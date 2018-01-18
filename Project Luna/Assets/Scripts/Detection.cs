using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Collider collider;
    public Vector3 pos;

	// Use this for initialization
	void Start ()
    {
        collider = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            collider.enabled = !collider.enabled;
        }

        if(collider.enabled)
        {
            pos = transform.position;
        }
    }
}
