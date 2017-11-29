using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeAbility
{

    [MenuItem("Assets/Scripts/Ability")]
    public static void CreateMyAsset()
    {
        Ability asset = ScriptableObject.CreateInstance<Ability>();


        AssetDatabase.CreateAsset(asset, "Assets/Scripts/NewAbility.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
