using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuContrl : MonoBehaviour
{
    public GameObject panelPause;
    public Button buttonExit;
    public Button buttonRestart;
    private void Start()
    {
        buttonExit.onClick.AddListener(Exit);
        buttonRestart.onClick.AddListener(RestartLevel);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.sceneCount);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
}
