using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public GameObject RollerBall;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - RollerBall.transform.position;

		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = RollerBall.transform.position + offset;
	}
}
