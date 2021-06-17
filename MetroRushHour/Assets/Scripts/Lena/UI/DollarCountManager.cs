using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollarCountManager : MonoBehaviour
{
    public Text dollarText;
    int addingTemp = 0;

    public void DollarsAdd(int dollars, bool add)
    {
        if (add)
        {
            addingTemp = +1;
        }
        else addingTemp = -1;

        if ((Dollar.dollarSum + dollars * addingTemp) <= 0)
        {
            Dollar.dollarSum = 0;
        }
        else
        {
            Dollar.dollarSum += dollars * addingTemp;
        }

        dollarText.text = "Dollars: " + Dollar.dollarSum.ToString() + " / " + Dollar.dollarFinal.ToString();

    }
}
