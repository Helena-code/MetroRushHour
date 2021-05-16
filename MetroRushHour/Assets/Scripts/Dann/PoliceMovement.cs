using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMovement : MonoBehaviour
{
    Transform player;
    Vector3 endPosition;
    bool playerCaught = false;
    bool playerInSight = false;
    void Start()
    {
        endPosition = new Vector3(
            -transform.position.x, 
            transform.position.y, 
            transform.position.z);
    }
    void Update()
    {
        if (transform.position == endPosition)
        {
            
        }
        if (playerCaught)
        {
            return;
        }
        if (playerInSight)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 3 * Time.deltaTime);
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= 1f)
            {
                playerCaught = true;
                Debug.Log(playerCaught);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, 2 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            ChasePlayer(other.transform);
        }
    }
    private void OnTriggerStay(Collider other) 
    {
       if (other.gameObject.tag == "Player")
        {
            ChasePlayer(other.transform);
        } 
    }
    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            playerInSight = false;
        } 
    }
    void ChasePlayer(Transform other)
    {
        player = other;
        playerInSight = true;
    }
}
