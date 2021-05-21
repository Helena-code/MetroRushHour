using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    Color endColor;
    Color playerColor;
    public GameObject skinPlayer;
    void Start()
    {
        //playerColor = GetComponent<MeshRenderer>().material.color;
        //endColor = new Color(255f, 0f, 0f, 100f);
        endColor = new Color(191f, 5f, 5f, 100f);
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.C))
        //{
        //    GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        //}
    }
   public void ChangeColor()
    {
        //GetComponentInChildren<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color = Color.Lerp(skinPlayer.GetComponent<SkinnedMeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        
    }
}
