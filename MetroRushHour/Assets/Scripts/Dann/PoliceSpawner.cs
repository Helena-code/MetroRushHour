using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
 
    public float spawningPositionX = 22f;
    public GameObject player;
    public GameObject police;
    Vector3 playerPosition;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SpawnPolice();
        }
    }
    void SpawnPolice()
    {
        if (!FindObjectOfType<PoliceMovement>())
        {
            playerPosition = player.transform.position;
            if (playerPosition.x > 0)
            {
                Instantiate(police, new Vector3(-spawningPositionX, playerPosition.y, playerPosition.z), Quaternion.Euler(0f, -180f, 0f));
            }
            else
            {
                Instantiate(police, new Vector3(spawningPositionX, playerPosition.y, playerPosition.z), Quaternion.identity);
            }
        }                
    }              
}
