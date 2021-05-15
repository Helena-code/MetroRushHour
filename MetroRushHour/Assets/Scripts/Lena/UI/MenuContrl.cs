using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuContrl : MonoBehaviour
{
   public GameObject panelPause;

    public void PauseGame()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        // обнуление прогресса!!
    }
    public void Continue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
