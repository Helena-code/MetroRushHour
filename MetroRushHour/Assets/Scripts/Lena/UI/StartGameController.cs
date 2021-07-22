using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    float loadingTime = 50f;


    public void PlayGame()
    {
        Invoke(nameof(Met), loadingTime);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Met()
    {
        SceneManager.LoadScene("GameScene");
    }
}
