using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceDestroyer : MonoBehaviour
{
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Police")
        {
            Destroy(other.gameObject);
        }
    }
}
