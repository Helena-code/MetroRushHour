using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    public GameObject slideShowBeginning;
    public GameObject slideShowCatch;
    public GameObject slideShowEndGood;
    public GameObject slideShowEndBad;
    private void Awake()
    {
        slideShowBeginning.SetActive(false);
        slideShowCatch.SetActive(false);
        slideShowEndGood.SetActive(false);
        slideShowEndBad.SetActive(false);
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
    public void StartSlideCatch()
    {
        slideShowCatch.SetActive(true);
    }
    public void StartSlideEndGood()
    {
        slideShowEndGood.SetActive(true);
    }
    public void StartSlideEndBad()
    {
        slideShowEndBad.SetActive(true);
    }
    
}
