using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityAction onNextScene;
    public UnityAction onExitGame;
    public Button StartButton;
    public Button ExitButton;

    void Start()
    {
        onExitGame = ExitFromGame;
        onNextScene = NextScene;
        StartButton.onClick.AddListener(onNextScene);
        ExitButton.onClick.AddListener(onExitGame);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(SceneManager.sceneCount);
    }
    void NextScene()
    {
        if (SceneManager.sceneCount <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.sceneCount + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    void ExitFromGame()
    {
        Application.Quit();
    }
}
