using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainHelper : MonoBehaviour
{
    public GameObject train;
    public float timeToSwitchTrain;
    void Start()
    {
        Invoke("SwitchTrain", timeToSwitchTrain);
    }

    void SwitchTrain()
    {
        train.SetActive(true);
    }
}
