using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class CamFollow : MonoBehaviour    // for putting scr on actual main camera
//{
//    public Transform follow_target;

//    public Vector3 camera_offset;


//    private float zoom_current = 1.0f;
//    public float zoom_speed = 3.0f;
//    public float zoom_min = 0.5f;
//    public float zoom_max = 5.0f;

//    public float smooth_speed = 0.15f;
//    public float yaw = 2.0f;


//    void Start ()
//    {
//        camera_offset = new Vector3(0.0f, 7.0f, -7.0f);
//    }

//    void Update()
//    {
//        zoom_current -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed;
//        zoom_current = Mathf.Clamp(zoom_current, zoom_min, zoom_max);
//    }

//    void FixedUpdate ()
//    {
//        Vector3 camera_dest = follow_target.position + camera_offset * zoom_current;
//        Vector3 camera_smooth_to_pos = Vector3.Lerp(transform.position, camera_dest, smooth_speed);
//        transform.position = camera_smooth_to_pos;

//        transform.LookAt(follow_target.position + Vector3.up * yaw);
//    }
//}


public class CamFollow : MonoBehaviour  // for putting scr directly on player character
{
    //public Transform follow_target;
    Camera cam_follow;

    public Vector3 camera_offset;


    private float zoom_current = 1.0f;
    public float zoom_speed = 3.0f;
    public float zoom_min = 0.5f;
    public float zoom_max = 3.0f;

    public float smooth_speed = 0.15f;
    public float yaw = 2.0f;


    void Start()
    {
        cam_follow = Camera.main;
        camera_offset = new Vector3(0.0f, 7.0f, -7.0f);
    }

    void Update()
    {
        zoom_current -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed;
        zoom_current = Mathf.Clamp(zoom_current, zoom_min, zoom_max);
    }

    void FixedUpdate()
    {
        Vector3 camera_dest = transform.position + camera_offset * zoom_current;
        Vector3 camera_smooth_to_pos = Vector3.Lerp(cam_follow.transform.position, camera_dest, smooth_speed);
        cam_follow.transform.position = camera_smooth_to_pos;

        cam_follow.transform.LookAt(transform.position + Vector3.up * yaw);
    }
}
