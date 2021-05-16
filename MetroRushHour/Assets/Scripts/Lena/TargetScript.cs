using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    public int typeOfTarget;

    string currentTarget;
    //public string targetPositive = "targetPositive";
    //public string targetNegative;
    //public string Crowd;
    public Transform stPos;
    Slider currentSlider;
    void Awake()
    {
        switch (typeOfTarget)
        {
            case 1:
                currentTarget = "targetPositive";
                break;
            case 2:
                currentTarget = "targetNegative";
                break;
            case 3:
                currentTarget = "targetCrowd";
                break;
        }

        // currentSlider = GetComponentInChildren<Slider>();
        GameObject slInst = Instantiate(Resources.Load("SliderRob")) as GameObject;
        
        slInst.transform.SetParent(stPos);
        //slInst.transform.position = Vector3.up;
        slInst.GetComponent<Slider>().transform.localPosition = Vector3.up;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<TestPlayerScript>() != null)
        {
            other.GetComponent<TestPlayerScript>().TargetingOn(currentTarget, currentSlider);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TestPlayerScript>() != null)
        {
            other.GetComponent<TestPlayerScript>().TargetingOff();
        }
    }
}
