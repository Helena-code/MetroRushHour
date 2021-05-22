using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    public Text dollars;

    private void Update()
    {
        dollars.text = Dollar.dollarSum.ToString();
    }
    public void GoToScene()
    {
        SceneManager.LoadScene(0);
    }
}
