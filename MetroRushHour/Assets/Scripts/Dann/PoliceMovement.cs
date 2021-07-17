using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PoliceMovement : MonoBehaviour
{
    public float walkingSpeed = 2f;
    public float chasingSpeed = 3f;

    Transform player;
    Vector3 endPosition;
   // bool playerCaught = false;
    bool playerInSight = false;
   
    //public UnityAction onPlayerLose;


    void Start()
    {
        //endPosition = new Vector3(-transform.position.x + 50, transform.position.y, transform.position.z); 
        endPosition = new Vector3(-transform.position.x*2f, transform.position.y, transform.position.z); // TODO проверить работу и удалить

    }

    void Update()
    {
        if (playerInSight)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, chasingSpeed * Time.deltaTime);
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= 1f)
            {
                // TODO юнитиэкшн что делает, а также убрать загрузку сцены, если будет куда
                //playerCaught = true;
                SceneManager.LoadScene(2);
                //if (onPlayerLose != null)
                //{
                //    onPlayerLose.Invoke();
                //}
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
