using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
 
    public Vector3 spawningPosition = new Vector3(22f, 0f, 0f);
    public GameObject player;
    public GameObject police;
    Vector3 playerPosition;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (police != null)
            {
                playerPosition = player.transform.position;
                if (playerPosition.x > 0)
                {
                    Instantiate(police, new Vector3(-spawningPosition.x, spawningPosition.y, spawningPosition.z), Quaternion.Euler(0f, -180f, 0f));
                }
                else
                {
                    Instantiate(police, new Vector3(spawningPosition.x, spawningPosition.y, spawningPosition.z), Quaternion.identity);
                }
            }
        }
    }
}
