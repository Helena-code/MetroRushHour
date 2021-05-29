using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSlideBadScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SlideManager>().StartSlideEndBad();
    }
}
