using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour {

    public float field_of_view;

    private bool player_in_view;
    private SphereCollider col;

    float test = 0;
    bool gate = true;


    void Awake ()
    {
        field_of_view = 45.0f;
        player_in_view = false;
        col = transform.GetChild(1).GetComponent<SphereCollider>();
    }


    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "PlayerParent")
        {
            //player_in_view = false;

            Vector3 dir = other.transform.position - transform.position;
            float view_angle = Vector3.Angle(dir, transform.forward);

            if (view_angle < field_of_view * 0.5f)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position + transform.up, dir.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject.GetComponent<Transform>().tag == "PlayerParent")
                    {
                        // run towards player or some other action

                        Debug.Log("Hey");
                    }
                }
            }
        }
    }
}
