using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    public GameObject slideShowBeginning;
    public GameObject slideShowCatch;
    public GameObject slideShowEndGood;
    public GameObject slideShowEndBad;
    public GameObject panelRepeat;

    StartGameController startScript;
    bool isShowing;
    bool isFirstSlade;

    private void Awake()
    {
        slideShowBeginning.SetActive(false);
        slideShowCatch.SetActive(false);
        slideShowEndGood.SetActive(false);
        slideShowEndBad.SetActive(false);
        isShowing = false;
        isFirstSlade = false;
        startScript = GetComponent<StartGameController>();
        panelRepeat.SetActive(false);
    }

    private void Update()
    {
        if (isShowing && Input.GetKeyDown(KeyCode.Space))
        {
            if (isFirstSlade)
            {
                startScript.Met();
            }
            else
            {
                panelRepeat.SetActive(true);

                // TODO добавить запуск панели рестарта, убрать музыку
            }
        }
    }

    public void StartSlideBeginning()
    {
        slideShowBeginning.SetActive(true);
        isFirstSlade = true;
        isShowing = true;
    }
    public void StartSlideCatch()
    {
        slideShowCatch.SetActive(true);
        isShowing = true;
    }
    public void StartSlideEndGood()
    {
        slideShowEndGood.SetActive(true);
        isShowing = true;
    }
    public void StartSlideEndBad()
    {
        slideShowEndBad.SetActive(true);
        isShowing = true;
    }

}
