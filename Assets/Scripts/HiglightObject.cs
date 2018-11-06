using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiglightObject : MonoBehaviour {

    private Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;

	private void OnMouseEnter()
	{
        startColor = GetComponent<Renderer>().material.color;
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
	}

	private void OnMouseExit()
	{
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
	}
}
