using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiglightObject : MonoBehaviour {

    public SpriteRenderer spriteObjeto;
    private Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;



	private void OnMouseEnter()
	{
        startColor = spriteObjeto.color;
        mouseOver = true;
        spriteObjeto.color = mouseOverColor;
	}

	private void OnMouseExit()
	{
        mouseOver = false;
        spriteObjeto.color = startColor;
	}
}
