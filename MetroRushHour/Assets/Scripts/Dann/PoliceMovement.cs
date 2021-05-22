using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PoliceMovement : MonoBehaviour
{
    Transform player;
    Vector3 endPosition;
    bool playerCaught = false;
    bool playerInSight = false;
    public float walkingSpeed = 2f;
    public float chasingSpeed = 3f;
    public UnityAction onPlayerLose;
    void Start()
    {
        endPosition = new Vector3(-50f, transform.position.y, transform.position.z);
        // -transform.position.x, 

    }
    void Update()
    {
        if (transform.position == endPosition)
        {
            
        }
        if (playerCaught)
        {
            // return;
        }
        if (playerInSight)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, chasingSpeed * Time.deltaTime);
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= 1f)
            {
                playerCaught = true;
                SceneManager.LoadScene(2); // ÐÎÌÊÀ ÂÀÍËÀÂ ÌÎËÎÄÅÖ!!!
                if (onPlayerLose != null)
                {
                    onPlayerLose.Invoke();
                }
                // Debug.Log(playerCaught);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, walkingSpeed * Time.deltaTime);
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
