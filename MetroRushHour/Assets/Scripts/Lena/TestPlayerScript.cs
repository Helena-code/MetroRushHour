using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerScript : MonoBehaviour
{
    Rigidbody rigidbodyPlayer;
    Transform transformPlayer;
    Collider colliderPlayer;
    float horizontal;
    //float vertical;
    public float speed = 4f;
    public float pointBorderLeft;
    public float pointBorderRight;

    Animator animatorPlayer;
    public Transform forwardPoint;
    public GameObject skin;

    Vector3 currentMovement;
    string typeOfTarget;
    public Text positiveTargetSumText;
    int positiveTargetSum;

    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        transformPlayer = GetComponent<Transform>();
        colliderPlayer = GetComponent<Collider>();
        animatorPlayer = GetComponentInChildren<Animator>();

        //animatorPlayer.SetBool("Walk", false);
    }
    private void FixedUpdate()
    {

    }
    private void Update()
    {
        Moving();

        if (Input.GetKey(KeyCode.Space))
        {
            if (typeOfTarget == "targetPositive")
            {
                // тут еще должно быть взаимодействие с самим таргетом - таймер ползунок
                positiveTargetSum = positiveTargetSum + 1;
                positiveTargetSumText.text += " " + positiveTargetSum.ToString();
            }
        }
        
    }
    private void Moving()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (transformPlayer.position.x < pointBorderLeft)
        {
            if (horizontal > 0)
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            else
                horizontal = 0.0f;
        }
        else if (transformPlayer.position.x > pointBorderRight)
        {
            if (horizontal < 0)
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            else
                horizontal = 0.0f;
        }

        currentMovement = new Vector3(horizontal, 0.0f, 0.0f);
        transformPlayer.Translate(currentMovement * speed * Time.deltaTime);

        //if (horizontal != 0)
        //{
        //    //animatorPlayer.SetBool("Walk", true);
        //}
        //else //animatorPlayer.SetBool("Walk", false);


    }

    public void TargetingOn(string type)
    {
        typeOfTarget = type;
    }
    public void TargetingOff()
    {
        typeOfTarget = null;
    }

}
