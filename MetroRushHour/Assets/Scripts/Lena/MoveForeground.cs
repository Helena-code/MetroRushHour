using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForeground : MonoBehaviour
{
    public enum speedVariant
    {
        slow,
        fast,
    }

    public GameObject skin;
    public speedVariant speed;

    Transform transformCrowd;
    Vector3 currentMovement;
    Vector3 valueReversal;
    float borderMove1 = -30f;
    float borderMove2 = 30f;
    float speedValue;
    float coefReversal = -1f;



    void Start()
    {
        transformCrowd = GetComponent<Transform>();

        switch (speed)
        {
            case (speedVariant.slow):
                speedValue = 1.2f;
                skin.GetComponent<Animator>().speed = 1.2f;
                break;
            case (speedVariant.fast):
                speedValue = 2f;
                skin.GetComponent<Animator>().speed = 1.7f;
                break;
        }
            
        skin.GetComponent<Animator>().SetBool("Walk", true);
        valueReversal = new Vector3(0f, 180f, 0f);
    }


    void Update()
    {
        currentMovement = Vector3.right * Time.deltaTime* speedValue;
        transformCrowd.Translate(currentMovement* coefReversal);
        if (transformCrowd.position.x < borderMove1 || transformCrowd.position.x > borderMove2)
        {
            coefReversal *= -1;
            skin.transform.Rotate(valueReversal);     
        }
        
    }
}
