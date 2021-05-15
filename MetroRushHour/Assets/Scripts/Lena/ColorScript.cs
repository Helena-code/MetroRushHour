using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    Renderer cubeRenderer;
    public float valueForColor;
    //Color color1;
    //Color color2;
    //Color color3;
    //Color color4;
    //Color color5;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        //cubeRenderer.material.color = new Color(171f, 2f, 2f, 100f);
        //color1 = new Color(171f, 2f, 2f, 100f);
        //color2 = new Color(129f, 37f, 1f, 100f);
        //color3 = new Color(91f, 69f, 1f, 100f);
        //color4 = new Color(48f, 105f, 0f, 100f);
        //color5 = new Color(11f, 136f, 0f, 100f);
    }

    void Update()
    {
        ChangeColor(valueForColor);
    }
    void ChangeColor(float value)
    {
        switch (value)
        {
            case 1:
                //cubeRenderer.material.color = color1;
                cubeRenderer.material = mat1;
                break;
            case 2:
                //cubeRenderer.material.color = color2;
                cubeRenderer.material = mat2;
                break;
            case 3:
                //cubeRenderer.material.color = color3;
                cubeRenderer.material = mat3;
                break;
            case 4:
                //cubeRenderer.material.color = color4;
                cubeRenderer.material = mat4;
                break;
            case 5:
                //cubeRenderer.material.color = color5;
                cubeRenderer.material = mat5;
                break;
        }
    }
}
