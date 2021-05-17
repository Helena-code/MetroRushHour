using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    public GameObject slideShowBeginning;
    private void Awake()
    {
        slideShowBeginning.SetActive(false);
    }
    private void Update()
    {
        //реяр сдюкхрэ бшгнб лемедфепю яжем
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartSlideBeginning();
        }

    }
    public void StartSlideBeginning()
    {
        slideShowBeginning.SetActive(true);
    }
}
