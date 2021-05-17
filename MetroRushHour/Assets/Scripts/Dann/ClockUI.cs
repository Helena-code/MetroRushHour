using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    Image timer;
    public float timeAmount = 20;
    float time;
    Transform clockHandTransform;
    // Start is called before the first frame update
    void Start()
    {
        timer = transform.Find("ClockTimer").GetComponentInChildren<Image>();
        time = timeAmount;
        clockHandTransform = transform.Find("ClockHandMoving");
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timer.fillAmount = time / timeAmount;
            clockHandTransform.eulerAngles = new Vector3 (0, 0, timer.fillAmount * 360);
        }
    }
}
