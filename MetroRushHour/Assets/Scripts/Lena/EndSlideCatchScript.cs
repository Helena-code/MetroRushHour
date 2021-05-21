using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSlideCatchScript : MonoBehaviour
{

    //public GameObject slideShowMan;
    private void Start()
    {
       // slideShowMan.GetComponent<SlideManager>().StartSlideCatch();
        GetComponent<SlideManager>().StartSlideCatch();
    }
}
