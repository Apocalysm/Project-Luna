using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Ability/Ability", order = 1 )]
public class Ability : ScriptableObject
{
    public string objectName = "New MyScriptableObject";
    public bool colorIsRandom = false;
    public Color thisColor = Color.white;
    public Vector3[] spawnPoints;
}
