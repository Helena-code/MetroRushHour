using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameSceneUIScript : MonoBehaviour
{
    public Button buttonExit;
    public Button buttonRestart;
    private void Start()
    {
        buttonExit.onClick.AddListener(Exit);
        buttonExit.onClick.AddListener(RestartLevel);
    }

    void Update()
    {

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
