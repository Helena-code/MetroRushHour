using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DollarCountManager : MonoBehaviour
{
    public Text dollarText;
    int addingTemp = 0;

    public  int dollarSum;
    public  int dollarFinal;

    private void Awake()
    {
       // dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();
       // dollarText.text = "Dollars: " + dollarSum.ToString() + " / " + dollarFinal.ToString();
        dollarText.text = "Dollars белеберда ";
    }
    private void Update()
    {
        dollarText.text = "Dollars: " + dollarSum.ToString() + " / ";
    }
    public void DollarsAdd(int dollars, bool add)
    {
        Debug.Log("вызов добавления долларов");
        if (add)
        {
            addingTemp = +1;
        }
        else addingTemp = -1;

        //if ((dollarSum + dollars * addingTemp) <= 0)
        //{
        //    dollarSum = 0;
        //}
        //else
        //{
            dollarSum += dollars * addingTemp;
        //}
        Debug.Log("Dollar.dollarSum  "+ dollarSum);
        dollarText.text = "Dollars: " + dollarSum.ToString() + " / "; //+ Dollar.dollarFinal.ToString();
        Debug.Log("строка за обновлением  ");
        Debug.Log("якобы обновленная dollarText.text  " + dollarText.text);

        //if (dollarSum >= dollarFinal)
        //{
        //    Invoke("StartFinalScene", 1f);
        //}


        //if ((Dollar.dollarSum + dollars * addingTemp) <= 0)
        //{
        //    Dollar.dollarSum = 0;
        //}
        //else
        //{
        //    Dollar.dollarSum += dollars * addingTemp;
        //}
        //// Debug.Log("Dollar.dollarSum  "+ Dollar.dollarSum);
        //dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / "; //+ Dollar.dollarFinal.ToString();


        //if (Dollar.dollarSum >= Dollar.dollarFinal)
        //{
        //    Invoke("StartFinalScene", 1f);
        //}

    }

    void StartFinalScene()
    {
        SceneManager.LoadScene("GoodEndScene");
    }

}
