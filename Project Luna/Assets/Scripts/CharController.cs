using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 move_input;
    private Vector3 move_velocity;
    
    public float base_speed;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        move_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        move_velocity = move_input * base_speed;
	}

    private void FixedUpdate()
    {
        rb.velocity = move_velocity;
    }
}
