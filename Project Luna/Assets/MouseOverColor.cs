using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverColor : MonoBehaviour
{
    [SerializeField]
    Color mouseOverCol;

    Color orgColor;

    void OnMouseEnter()
    {
        orgColor = GetComponent<MeshRenderer>().material.color;
        GetComponent<MeshRenderer>().material.color = mouseOverCol;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = orgColor;
    }


}
