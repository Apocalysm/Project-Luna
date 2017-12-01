using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Ability/Ability", order = 1 )]
public abstract class Ability : ScriptableObject
{
    public string objectName = "New Ability";
    public int coolDown = 0;
    public Animation animation;
    public AudioClip audio;
    protected AudioSource source;
    public bool canUse = true;

    public virtual void Initialize(GameObject obj)
    {
        source = obj.GetComponent<AudioSource>();
        source.PlayOneShot(audio);
        //animation.Play();
        canUse = false;
    }
}

