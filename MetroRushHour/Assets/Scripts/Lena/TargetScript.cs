using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
    public int typeOfTarget;

    // string currentTarget;

    //public string targetPositive = "targetPositive";
    //public string targetNegative;
    //public string Crowd;

    public Transform slPos;
    Slider currentSlider;
    public GameObject skin;
    public Material greyMat;
    public Text dollarText;

    public int robStage = 0;
    public int numTryToRob = 0;
    public int valueDollarGoodPerson;
    public int valueDollarBadPerson;
    public int valueDollarUnluck;

    public bool sliderLevel1;
    public bool sliderLevel2;
    public bool sliderLevel3;


    void Awake()
    {
        //switch (typeOfTarget)
        //{
        //    case 1:
        //        currentTarget = "targetPositive";
        //        break;
        //    case 2:
        //        currentTarget = "targetNegative";
        //        break;
        //    case 3:
        //        currentTarget = "targetCrowd";
        //        break;
        //}

        // currentSlider = GetComponentInChildren<Slider>();

        GameObject slInst = Instantiate(Resources.Load("SliderRob")) as GameObject;
        slInst.transform.SetParent(slPos);
        //slInst.transform.position = Vector3.up;
        slInst.GetComponent<Slider>().transform.localPosition = Vector3.up;
        currentSlider = slInst.GetComponent<Slider>();
        //currentSlider.enabled = false;
        //slPos.gameObject.
        if (sliderLevel1)
        {
            currentSlider.gameObject.GetComponent<SliderRob>().speed = SliderSpeed.sliderSpeedL1;
        }
        if (sliderLevel2)
        {
            currentSlider.gameObject.GetComponent<SliderRob>().speed = SliderSpeed.sliderSpeedL2;
        }
        if (sliderLevel3)
        {
            currentSlider.gameObject.GetComponent<SliderRob>().speed = SliderSpeed.sliderSpeedL3;
        }
        currentSlider.gameObject.SetActive(false);


    }
    private void Update()
    {
        if (numTryToRob == 1)
        {
            Invoke("ChangeColorRubLucky", 0f);

        }

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    if (robStage == 0)
        //    {
        //        Invoke("StageRob1", 0.5f);
        //        //StageRob1();
        //        Debug.Log("нажат пробел в Target стадия 1");

        //    }
        //    if (robStage == 1)
        //    {
        //        Debug.Log("нажат пробел в Target стадия 2");
        //        //Invoke("StageRob2(other)", 0.5f);
        //        //StageRob2(other);
        //    }

        //}

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<TestPlayerScript>() != null)
        {
            //    other.GetComponent<TestPlayerScript>().TargetingOn(currentTarget, currentSlider);
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (robStage == 0)
                {
                    Invoke("StageRob1", 0.2f);
                    //StageRob1();
                    Debug.Log("нажат пробел в Target стадия 1");

                }
                if (robStage == 1)
                {
                    Debug.Log("нажат пробел в Target стадия 2");
                    //Invoke("StageRob2(other)", 0.5f);
                    StageRob2(other);
                }

            }




            //    if (robStage == 0)
            //{
            //    if (Input.GetKeyUp(KeyCode.Space))
            //    {
            //        Debug.Log("нажат пробел в Target");
            //        //currentSlider.enabled = true;
            //        currentSlider.gameObject.SetActive(true);
            //        robStage = 1;
            //    }
            //}
            //if (robStage == 1)
            //{
            //    if (Input.GetKeyUp(KeyCode.Space))
            //    {
            //        if (typeOfTarget == 1)
            //        {

            //            if (currentSlider.value < 0.3f || currentSlider.value > 0.7f)
            //            {
            //                other.GetComponent<TestPlayerScript>().MoveRobUnluck();
            //                Dollar.dollarSum -= valueDollarUnluck;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                return;
            //            }
            //            else
            //            {
            //                //Debug.Log("попала в зеленую полосу");

            //                other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
            //                numTryToRob = 1;
            //                Dollar.dollarSum += valueDollarGoodPerson;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                robStage = 2;
            //                return;
            //            }
            //        }

            //        if (typeOfTarget == 2)
            //        {

            //            if (currentSlider.value < 0.3f || currentSlider.value > 0.7f)
            //            {
            //                other.GetComponent<TestPlayerScript>().MoveRobUnluck();
            //                Dollar.dollarSum -= valueDollarUnluck;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                return;
            //            }
            //            else

            //            {
            //                //other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
            //                numTryToRob = 1;
            //                Dollar.dollarSum += valueDollarBadPerson;
            //                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
            //                robStage = 2;
            //                return;
            //            }
            //        }
            //    }
            //}
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //if (other.GetComponent<TestPlayerScript>() != null)
        //{
        //    other.GetComponent<TestPlayerScript>().TargetingOff();
        //}
        currentSlider.gameObject.SetActive(false);
    }
    public void ChangeColorRubLucky()
    {
        skin.GetComponent<MeshRenderer>().material = greyMat;
        //currentSlider.enabled = false;
        currentSlider.gameObject.SetActive(false);
        Destroy(GetComponent<TargetScript>());

    }

    void StageRob1()
    {
        //Debug.Log("нажат пробел в Target стадия 1");
        currentSlider.gameObject.SetActive(true);
        robStage = 1;
    }

    void StageRob2(Collider player)
    {
        Collider other = player;

        if (typeOfTarget == 1)
        {

            if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)
            {
                other.GetComponent<TestPlayerScript>().MoveRobUnluck();
                if ((Dollar.dollarSum - valueDollarUnluck) <= 0)
                {
                    Dollar.dollarSum = 0;
                }
                else { Dollar.dollarSum -= valueDollarUnluck; }

                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
                numTryToRob = 1;
                return;
            }
            else
            {
                //Debug.Log("попала в зеленую полосу");

                other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
                numTryToRob = 1;
                Dollar.dollarSum += valueDollarGoodPerson;
                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
                robStage = 2;
                Debug.Log("успех ограбление хороший");
                return;
            }
        }
        if (typeOfTarget == 2)
        {

            if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)
            {
                other.GetComponent<TestPlayerScript>().MoveRobUnluck();
                if ((Dollar.dollarSum - valueDollarUnluck) <= 0)
                {
                    Dollar.dollarSum = 0;
                }
                else { Dollar.dollarSum -= valueDollarUnluck; }
                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
                numTryToRob = 1;
                return;
            }
            else

            {
                //other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
                numTryToRob = 1;
                Dollar.dollarSum += valueDollarBadPerson;
                dollarText.text = "Dollars: " + Dollar.dollarSum.ToString();
                robStage = 2;
                Debug.Log("успех ограбление плохой");
                return;
            }
        }
    }
}
