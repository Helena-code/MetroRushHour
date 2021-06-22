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
    public Transform rightPoint;
    public Transform leftPoint;
    public Transform frontPoint;
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

        // перенесено в долларменеджер
        //if (Dollar.dollarSum >= Dollar.dollarFinal)
        //{
        //    SceneManager.LoadScene("GoodEndScene");
        //}

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
        //            //Debug.Log("попала в зеленую полосу");
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
        //            //Debug.Log("попала в зеленую полосу");
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
            animatorPlayer.SetBool("Steal", false);
            animatorPlayer.SetBool("Run", true);
            if (horizontal < 0)
            {
                skin.transform.LookAt(leftPoint);
                //skin.transform.Rotate(0,90,0);
            }
            else if (horizontal > 0)
            {
                skin.transform.LookAt(rightPoint);
                //skin.transform.Rotate(0, -90, 0);
            }
        }
        else animatorPlayer.SetBool("Run", false);

    }

    public void TargetingOn(string type, Slider currentSl)            // ???? что это?? удалить
    {
        Debug.Log("метод TargetingOn");
        typeOfTarget = type;
        currentSliderRob = currentSl;
    }
    public void TargetingOff()                     // ???? что это?? удалить
    {
        typeOfTarget = null;
    }

    public void MoveRobUnluckPlayer()
    {
        // тут тоже надо вынесли плавное отодвигание - в апдейт
        // включить анимацию шаг
        Vector3 currentPos = transformPlayer.position;
        currentPos.x += 1.5f;
        transformPlayer.position = currentPos;
        // выключить анимацию шаг
    }

    public void LookAtTarget(Vector3 targetPos)
    {
        //Debug.Log("вызов LookAt у игрока");
       skin.transform.LookAt(targetPos,Vector3.up);
       // skin.transform.LookAt(targetPos);
       // skin.transform.LookAt(new Vector3 (0,0,targetPos.z));
       // skin.transform.LookAt(transform.forward);
       // skin.transform.LookAt(Vector3.forward);
    }

    public void StopAnimPlayer(bool isRobbed)
    {
        if (isRobbed)
        {
            Invoke("StopAnim", 0.5f);
            //animatorPlayer.SetBool("StealYes", false);
        }
    }

    public void StopAnim()
    {
        animatorPlayer.SetBool("StealYes", false);
    }
}
