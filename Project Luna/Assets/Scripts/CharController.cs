using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CharController : MonoBehaviour
//{
//    private Rigidbody rb;

//    private Vector3 move_input;
//    private Vector3 move_velocity;

//    public float base_speed = 100;

//    void Start ()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//	void Update ()
//    {
//        move_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
//        move_velocity = move_input * base_speed * Time.deltaTime;
//	}

//    private void FixedUpdate()
//    {
//        rb.velocity = move_velocity;
//    }
//}


public class CharController : MonoBehaviour
{
    Rigidbody rb;
    
    public float speed_base = 10;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Vector3 move_vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        move_vec = move_vec.normalized;

        transform.Translate(move_vec * speed_base * Time.deltaTime);
    }
}