using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargets : MonoBehaviour
{
    TimeToTalkScript crowdScript;
    TargetScript greenAndRedTargetScript;
    Types.typeOfTarget currentType;

    public void SetType(Types.typeOfTarget typeOfTarget)
    {
        currentType = typeOfTarget;
    }
    public void DestroyTarget()
    {
        switch (currentType)
        {
            case (Types.typeOfTarget.yellow):

                crowdScript = GetComponent<TimeToTalkScript>();
                crowdScript.DestroyTarget();
                break;
            case (Types.typeOfTarget.green):
                greenAndRedTargetScript = GetComponent<TargetScript>();
                greenAndRedTargetScript.DestroyTarget();
                break;
            case (Types.typeOfTarget.red):
                greenAndRedTargetScript = GetComponent<TargetScript>();
                greenAndRedTargetScript.DestroyTarget();
                break;
        }
    }
}
