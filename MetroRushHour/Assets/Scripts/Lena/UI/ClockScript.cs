using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    public Text timeDay;
    float timeStart = 6f;
    float timeCurrent;
    float secondsValue = 2f;
    float secondsValueCurrent;

    void Start()
    {
        timeDay.text = timeStart.ToString();
        timeCurrent = timeStart;
        secondsValueCurrent = 0;
    }

    void Update()
    {
        secondsValueCurrent += Time.deltaTime;
        if (Mathf.Abs(secondsValueCurrent - secondsValue) < 0.01f)
        {
            timeCurrent++;
            timeDay.text = timeCurrent.ToString();
            secondsValueCurrent = 0;
        }
    }
}
