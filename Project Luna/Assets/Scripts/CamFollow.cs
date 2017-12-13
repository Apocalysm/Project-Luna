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
    private Camera cam_follow;

    private Vector3 camera_offset;

    public float offset_x = 0.0f;
    public float offset_y = 7.0f;
    public float offset_z = -7.0f;

    private float zoom_current = 1.0f;
    public float zoom_speed = 3.0f;
    public float zoom_min = 0.5f;
    public float zoom_max = 2.0f;
    public float smooth_speed = 5.0f;
    public float pitch = 2.0f;


    void Start()
    {
        cam_follow = Camera.main;
    }

    void Update()
    {
        zoom_current -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed;
        zoom_current = Mathf.Clamp(zoom_current, zoom_min, zoom_max);

        float zoom_dest = zoom_current;
        float zoom_smooth = Mathf.Lerp(Input.GetAxis("Mouse ScrollWheel"), zoom_dest, 3 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 camera_dest = transform.position + new Vector3(offset_x, offset_y, offset_z) * zoom_current;
        Vector3 camera_smooth_to_pos = Vector3.Lerp(cam_follow.transform.position, camera_dest, smooth_speed * Time.deltaTime);
        cam_follow.transform.position = camera_smooth_to_pos;

        cam_follow.transform.LookAt(transform.position + Vector3.up * pitch);
    }
}
