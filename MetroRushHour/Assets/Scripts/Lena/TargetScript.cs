using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int typeOfTarget;

    string currentTarget;
    //public string targetPositive = "targetPositive";
    //public string targetNegative;
    //public string Crowd;

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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<TestPlayerScript>() != null)
        {
            other.GetComponent<TestPlayerScript>().TargetingOn(currentTarget);
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
