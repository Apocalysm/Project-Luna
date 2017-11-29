using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Ability/Ability", order = 1 )]
public abstract class Ability : ScriptableObject
{
    public string objectName = "New Ability";
    public int coolDown = 0;

    public abstract void Initialize(GameObject obj);
}

