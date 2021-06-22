using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHelper : MonoBehaviour
{
    public GameObject train;
    public float timeToSwitchTrain;
    void Start()
    {
        Invoke("SwitchOnTrain", timeToSwitchTrain);
    }

   public void SwitchOnTrain()
    {
        train.SetActive(true);
    }
   public void SwitchOffTrain()
    {
        train.SetActive(false);
    }
}
