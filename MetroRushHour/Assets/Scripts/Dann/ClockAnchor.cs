using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockAnchor : MonoBehaviour
{
    public Image clocks;
    Vector3 clockPosition;
    // Update is called once per frame
    void Update()
    {
        clockPosition = Camera.main.WorldToScreenPoint(transform.position);
        clocks.transform.position = clockPosition;
    }
}
