using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRob : MonoBehaviour
{
    Slider sliderRob;
    float speed = -0.5f;
    private void Awake()
    {
        sliderRob = GetComponent<Slider>();
        sliderRob.value = 0.11f;
    }
    void Update()
    {
        sliderRob.value += Time.deltaTime*speed;
        if (sliderRob.value > 0.9f)
        {
            //currentSliderRob.value -= Time.deltaTime;
            speed *= -1; 
        } else if (sliderRob.value < 0.1f)
        {
            //currentSliderRob.value += Time.deltaTime;
            speed *= -1;
        }
        
    }
}
