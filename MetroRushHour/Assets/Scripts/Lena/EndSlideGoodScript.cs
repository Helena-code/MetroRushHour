using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSlideGoodScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SlideManager>().StartSlideEndGood();
    }
}
