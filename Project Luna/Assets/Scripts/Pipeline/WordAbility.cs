using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu (menuName = "Abilities/Word")]
public class WordAbility : Ability
{

    public override void Initialize(GameObject luna, GameObject player)
    {
       

        if (luna.GetComponent<NavMeshAgent>().velocity == Vector3.zero)
        {
            luna.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }

        else
        {
            luna.GetComponent<NavMeshAgent>().SetDestination(luna.transform.position);
        }
    }
}
