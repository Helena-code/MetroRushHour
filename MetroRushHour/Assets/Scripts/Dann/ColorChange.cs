using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Color endColor;
    Color playerColor;
    public GameObject skinPlayer;
    public Material playerMaterial;

    float f = 0.5f;
    void Start()
    {
        //playerColor = GetComponent<MeshRenderer>().material.color;
        //endColor = new Color(255f, 0f, 0f, 100f);
        // endColor = new Color(191f, 5f, 5f, 100f);
        // endColor = new Color(255f, 255f, 255f, 0f);
        //endColor = new Color(255f, 0f, 0f, 255f);
        //endColor = new Color(1f, 0f, 0f, 1f);
        endColor = Color.red;
        playerMaterial = skinPlayer.GetComponent<SkinnedMeshRenderer>().material;

    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.C))
        //{
        //    GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        //}
        //skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color.a = skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color.a - Time.deltaTime;


        // TODO –¿¡Œ“¿ﬁŸ¿ﬂ œ–Œ«–¿◊ÕŒ—“‹, ”¡–¿“‹ ¬ Õ”∆ÕŒ≈ Ã≈—“Œ
        // Color color = playerMaterial.color;
        //// color = Color.Lerp(color, endColor, Time.deltaTime / 9f);

        // color.a = color.a - Time.deltaTime/9f;
        // playerMaterial.color = color;



        if (Input.GetKey(KeyCode.C))
        {
            //Color color = playerMaterial.color;
            //color = Color.Lerp(color, endColor, Time.deltaTime*50000f);
            //playerMaterial.color = color;

            //Color color = Color.red * f;
            //playerMaterial.SetColor("_EmissionColor", color);
            //f++;

            Color color = playerMaterial.color;
            color = Color.Lerp(color, endColor, 1f);
            playerMaterial.SetColor("_EmissionColor", color);
        }
    }
    public void ChangeColor()
    {
        //GetComponentInChildren<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        //  skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color, endColor, Time.deltaTime);


    }
}
