using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour {

    public float field_of_view;

    private bool player_in_view;
    private SphereCollider col;

    bool playerHit = false;

    float test = 0;
    bool gate = true;


    void Awake ()
    {
        field_of_view = 45.0f;
        player_in_view = false;
        col = transform.GetComponent<SphereCollider>();
    }


    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "PlayerParent")
        {
            //player_in_view = false;

            Vector3 dir = other.transform.position - transform.position;
            float view_angle = Vector3.Angle(dir, transform.forward);

            if (view_angle < field_of_view)
            {
                RaycastHit hit;
                bool bDidHit = Physics.Raycast(transform.position, dir.normalized, out hit, col.radius);
                if (Physics.Raycast(transform.position, dir.normalized, out hit, col.radius))
                {

                    if(hit.collider.gameObject.GetComponent<Transform>().tag == "PlayerParent")
                    {
                        // run towards player or some other action
                        transform.GetComponentInParent<NavMeshAgent>().speed = 6;
                        playerHit = true;
                        transform.GetComponentInParent<Ai>().goal = other.transform.position;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("PlayerParent") && playerHit)
        {
            playerHit = false;
            StartCoroutine(transform.GetComponentInParent<Ai>().CoolDown());
        }
    }
}
