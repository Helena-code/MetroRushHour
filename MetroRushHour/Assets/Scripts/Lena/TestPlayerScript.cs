using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Transform backPoint;
    public GameObject skin;

    Vector3 currentMovement;
    string typeOfTarget;
    public Text positiveTargetSumText;
    int positiveTargetSum;

    public Slider currentSliderRob;
    //int dollarsSum;
    //public Text dollarsSumText;
    public ColorChange colorchange;

    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        transformPlayer = GetComponent<Transform>();
        colliderPlayer = GetComponent<Collider>();
        animatorPlayer = GetComponentInChildren<Animator>();
        colorchange = GetComponent<ColorChange>();

        //animatorPlayer.SetBool("Walk", false);
    }
    private void FixedUpdate()
    {

    }
    private void Update()
    {
        Moving();

        if (Dollar.dollarSum >= Dollar.dollarFinal)
        {
            SceneManager.LoadScene("GoodEndScene");
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (typeOfTarget == "targetPositive")
        //    {

        //        //positiveTargetSum = positiveTargetSum + 1;
        //        //positiveTargetSumText.text += " " + positiveTargetSum.ToString();
        //        if (currentSliderRob.value < 0.4f || currentSliderRob.value > 0.6f)
        //        {
        //            Vector3 currentPos = transformPlayer.position;
        //            currentPos.x += 2f;
        //            transformPlayer.position = currentPos;
        //            return;
        //        } else
        //        {
        //            //Debug.Log("������ � ������� ������");
        //            //dollarsSum += 1;
        //            //dollarsSumText.text += dollarsSum.ToString();
        //            colorchange.ChangeColor();
        //            return;
        //        }
        //    }

        //        if (typeOfTarget == "targetNegative")
        //    {

        //        //positiveTargetSum = positiveTargetSum + 1;
        //        //positiveTargetSumText.text += " " + positiveTargetSum.ToString();
        //        if (currentSliderRob.value < 0.4f || currentSliderRob.value > 0.6f)
        //        {
        //            Vector3 currentPos = transformPlayer.position;
        //            currentPos.x += 2f;
        //            transformPlayer.position = currentPos;
        //            return;
        //        }
        //        else
        //        {
        //            //Debug.Log("������ � ������� ������");
        //            //dollarsSum += 1;
        //            //dollarsSumText.text += dollarsSum.ToString();
        //            //colorchange.ChangeColor();
        //            return;
        //        }
        //    }
        //}

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

        if (horizontal != 0)
        {
            animatorPlayer.SetBool("Run", true);
            if (horizontal < 0)
            {
                skin.transform.LookAt(backPoint);
            }
            else if (horizontal > 0)
            {
                skin.transform.LookAt(forwardPoint);
            }
        }
        else animatorPlayer.SetBool("Run", false);

    }

    public void TargetingOn(string type, Slider currentSl)
    {
        Debug.Log("����� TargetingOn");
        typeOfTarget = type;
        currentSliderRob = currentSl;
    }
    public void TargetingOff()
    {
        typeOfTarget = null;
    }

    public void MoveRobUnluck()
    {
        Vector3 currentPos = transformPlayer.position;
        currentPos.x += 2f;
        transformPlayer.position = currentPos;
    }
}
