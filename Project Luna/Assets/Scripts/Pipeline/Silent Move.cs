using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/SilentMove")]
public class SilentMove : Ability
{
    bool activated = false;

    public override void Initialize(GameObject luna, GameObject player)
    {
        if(!canUse && !activated)
        {
            luna.transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
            activated = true;
        }

        else if (!canUse && activated)
        {
            luna.transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
            activated = false;
        }
    }
}
