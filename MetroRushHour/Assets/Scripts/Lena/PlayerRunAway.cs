using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunAway : MonoBehaviour
{
    PlayerLogic playerScript;

    bool goAway;
    Vector3 endPoint;
    float playerPosZStart;

    private void Awake()
    {
        playerScript = GetComponent<PlayerLogic>();
        goAway = false;
        playerPosZStart = transform.position.z;
    }

    private void Update()
    {
        if (goAway)
        {
            
                transform.position = Vector3.MoveTowards(transform.position, endPoint, 2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, endPoint) < 0.3f)
            {
                playerScript.enabled = true;
                goAway = false;
            }
        }
    }

    public void MoveAway()
    {
        endPoint = transform.position;
        endPoint.z = playerPosZStart;
        goAway = true;
    }
}
