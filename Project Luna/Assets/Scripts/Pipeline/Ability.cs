using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Ability/Ability", order = 1)]
public abstract class Ability : ScriptableObject
{

    public string objectName = "New Ability";
    public int coolDown = 0;
    public Animation animation;
    public AudioClip audio;
    public int supplies;
    protected AudioSource source;
    public bool owned = false;
    [HideInInspector]
    public bool canUse = true;
    public bool haveUpdate = true;
    public bool passive = false;
    

    public virtual void Initialize(GameObject luna, GameObject player)
    {
        source = player.GetComponent<AudioSource>();
        source.PlayOneShot(audio);
        //animation.Play();
        canUse = false;
    }
}

