using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRob : MonoBehaviour
{
    Slider sliderRob;
  public  float speed;
    private void Awake()
    {
        sliderRob = GetComponent<Slider>();
        sliderRob.value = 0.15f;
    }
    void Update()
    {
        sliderRob.value += Time.deltaTime * speed;
        if (sliderRob.value > 0.9f)
        {
            //currentSliderRob.value -= Time.deltaTime;
            speed *= -1;
        }
        else if (sliderRob.value < 0.1f)
        {
            //currentSliderRob.value += Time.deltaTime;
            speed *= -1;
        }

    }
    //public void SetSliderLevel(bool l1, bool l2, bool l3)
    //{

    //}
}
