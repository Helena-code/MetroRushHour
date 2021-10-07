using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentTarget : MonoBehaviour
{
    public Material[] targetMaterials;
    public Material transparentMat;

    void Start()
    {
        targetMaterials = GetComponentsInChildren<Material>();
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            //foreach (var item in targetMaterials)
            //{
            //    item = transparentMat;
            //}
        }
        
    }
}
