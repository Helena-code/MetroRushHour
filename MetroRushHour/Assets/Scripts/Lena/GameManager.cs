using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject slideShowMan;
    public float loadingTime;
    public void PlayGame()
    {
        //slideShowMan.GetComponent<SlideManager>().slideShowBeginning();
        //SceneManager.LoadScene(1);
        Invoke(nameof (Met), loadingTime);
    }

     public void ExitGame()
    {
        Application.Quit();
    }
    
    void Met()
    {
        SceneManager.LoadScene("LenaScene");
    }
}
