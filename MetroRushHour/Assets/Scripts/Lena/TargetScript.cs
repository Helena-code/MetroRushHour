using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour
{
   // public int typeOfTarget;
    public Types.typeOfTarget currentType;
    // string currentTarget;

    //public string targetPositive = "targetPositive";
    //public string targetNegative;
    //public string Crowd;

    public Transform slPos;
    Slider currentSlider;
    public GameObject skinHead;           // голова
    public Material greyMat;
    //public Text dollarText;
    public GameObject dollarManager;
    DollarCountManager dollarCountManagerScript;
    public int robStage = 0;
    // public int numTryToRob = 0;
    public bool isRobbed;
    public int valueDollarPerson;
    public int valueDollarGoodPerson;
    public int valueDollarBadPerson;
    public int valueDollarUnluck;

    public bool sliderLevel1;
    public bool sliderLevel2;
    public bool sliderLevel3;

    public GameObject skinPlayer;
    public AudioSource audioSTarget;
    public AudioClip[] audioClipsRob;
    Animator animatorTarget;

    bool turnAroundIn;
    bool turnAroundOut;
    float timerTurnIn = 0f;
    float timerTurnOut = 0f;

    void Awake()
    {

        dollarCountManagerScript = dollarManager.GetComponent<DollarCountManager>();
        // currentSlider = GetComponentInChildren<Slider>();
        animatorTarget = GetComponentInChildren<Animator>();
        GameObject slInst = Instantiate(Resources.Load("SliderRob")) as GameObject;
        slInst.transform.SetParent(slPos);
        //slInst.transform.position = Vector3.zero;
        slInst.transform.localPosition = Vector3.zero;
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
        audioSTarget = GetComponent<AudioSource>();
        isRobbed = false;
        switch (currentType)
        {
            case Types.typeOfTarget.green:
                valueDollarPerson = valueDollarGoodPerson;
                break;
            case Types.typeOfTarget.red:
                valueDollarPerson = valueDollarBadPerson;
                break;
            case Types.typeOfTarget.yellow:
                valueDollarPerson = 0;
                break;
        }
    }
    private void Update()
    {
        if (isRobbed)           // зачем это тут? убрать куда надо
        {
            Invoke("ChangeColorRubLucky", 0f);

        }
        if (turnAroundIn)
        {
            timerTurnIn += Time.deltaTime;
            Vector3 _direction = (skinPlayer.transform.position - transform.position).normalized;
            Quaternion _LookRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _LookRotation, Time.deltaTime * 3f);
            if (timerTurnIn > 1f)
            {
                turnAroundIn = false;
                animatorTarget.SetBool("Rob", false);
                turnAroundOut = true;
            }
        }
        
        
        if (turnAroundOut)
        {
            timerTurnOut += Time.deltaTime;
           // Vector3 _direction = (skinPlayer.transform.position - transform.position).normalized;
            Quaternion _LookRotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, _LookRotation, Time.deltaTime * 2f);
            if (timerTurnOut > 1.5f)
            {
                turnAroundOut = false;
            }
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
                    //Debug.Log("нажат пробел в Target стадия 1");

                }
                if (robStage == 1)
                {
                    //Debug.Log("нажат пробел в Target стадия 2");
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
        //skin.GetComponent<MeshRenderer>().material = greyMat;
        //skinHead.GetComponentInChildren<SkinnedMeshRenderer>().material = greyMat;
        skinHead.GetComponent<SkinnedMeshRenderer>().material = greyMat;
        //currentSlider.enabled = false;
        currentSlider.gameObject.SetActive(false);
        //Destroy(GetComponent<TargetScript>());

    }
    public void DestroyTarget()
    {
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
        //skinPlayer.GetComponent<Transform>().LookAt(skinPlayer.GetComponent<TestPlayerScript>().frontPoint);
        skinPlayer.GetComponent<Animator>().SetBool("Steal", true);
        
        if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)          // неудачное ограбление
        {
            animatorTarget.SetBool("Rob", true);
            
            turnAroundIn = true;
            other.GetComponent<TestPlayerScript>().MoveRobUnluckPlayer();
            dollarCountManagerScript.DollarsAdd(valueDollarUnluck, false);
            
            audioSTarget.PlayOneShot(audioClipsRob[1]);
            //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
            
            currentSlider.gameObject.SetActive(false);
            isRobbed = true;
            return;
        }
        else                                                     // удачное ограбление
        {
            //Debug.Log("попала в зеленую полосу");
            audioSTarget.PlayOneShot(audioClipsRob[0]);
            if (currentType == Types.typeOfTarget.green)
            {
                other.GetComponent<TestPlayerScript>().colorchange.ChangeColor();
            }
            isRobbed = true;
            dollarCountManagerScript.DollarsAdd(valueDollarPerson, true);
           
            currentSlider.gameObject.SetActive(false);
            robStage = 2;
            // Debug.Log("успех ограбление хороший");
            //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
            return;
        }

    }
}
