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
    public GameObject skinHead;           // ������
    public Material greyMat;
    //public Text dollarText;
    public GameObject dollarManager;
    DollarCountManager dollarCountManagerScript;
    public GameObject particleMoney;
    public GameObject canRobIcon;
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
    public Vector3 targetPos;

    void Awake()
    {
        particleMoney.GetComponent<ParticleSystem>().Stop();
        canRobIcon.SetActive(false);
        // targetPos =transform.position;
        dollarManager = Camera.main.gameObject;
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
        if (isRobbed)           // ����� ��� ���? ������ ���� ����
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
        //        Debug.Log("����� ������ � Target ������ 1");

        //    }
        //    if (robStage == 1)
        //    {
        //        Debug.Log("����� ������ � Target ������ 2");
        //        //Invoke("StageRob2(other)", 0.5f);
        //        //StageRob2(other);
        //    }

        //}

    }
    private void OnTriggerEnter(Collider other)
    {
        canRobIcon.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerLogic>() != null)
        {
            //    other.GetComponent<TestPlayerScript>().TargetingOn(currentTarget, currentSlider);
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (robStage == 0)
                {
                    Invoke("StageRob1", 0.2f);
                    //StageRob1(other);
                    //Debug.Log("����� ������ � Target ������ 1");
                    // targetPos = transform.position;
                    //skinPlayer.GetComponentInChildren<Animator>().SetBool("Steal", true);

                    other.gameObject.GetComponent<PlayerLogic>().LookAtTarget(transform.position);
                    other.gameObject.GetComponentInChildren<Animator>().SetBool("Steal", true);
                    // return;
                }
                if (robStage == 1)
                {
                    //Debug.Log("����� ������ � Target ������ 2");
                    //Invoke("StageRob2(other)", 0.5f);
                    StageRob2(other);
                    // return;
                }

            }




            //    if (robStage == 0)
            //{
            //    if (Input.GetKeyUp(KeyCode.Space))
            //    {
            //        Debug.Log("����� ������ � Target");
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
            //                //Debug.Log("������ � ������� ������");

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
        canRobIcon.SetActive(false);
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
        //Destroy(GetComponent<TargetScript>());
        Destroy(this);

    }



    void StageRob1()
    {
        //Debug.Log("����� ������ � Target ������ 1");
        currentSlider.gameObject.SetActive(true);

        //skinPlayer.GetComponentInChildren<Animator>().SetBool("Steal", true);
        //if (skinPlayer.GetComponentInChildren<Animator>() != null)
        //{
        //    Debug.Log("�������� ������ ������");
        //}
        robStage = 1;
    }

    void StageRob2(Collider player)
    {
        Collider other = player;
        // other.gameObject.GetComponent<TestPlayerScript>().LookAtTarget(targetPos);

        //skinPlayer.GetComponent<Transform>().LookAt(skinPlayer.GetComponent<TestPlayerScript>().frontPoint);
        //skinPlayer.GetComponentInChildren<Animator>().SetBool("Steal", true);

        //other.gameObject.GetComponentInChildren<Animator>().SetBool("Steal", true);


        //if (other.gameObject.GetComponentInChildren<Animator>() != null)
        //{
        //    Debug.Log("�������� ������ ������");
        //}
        //if (skinPlayer.GetComponentInChildren<Animator>() != null)
        //{
        //    Debug.Log("�������� ������ ������");
        //}


        if (currentSlider.value < 0.25f || currentSlider.value > 0.5f)          // ��������� ����������
        {
            animatorTarget.SetBool("Rob", true);
            // player.gameObject.GetComponentInChildren<Animator>().SetBool("Steal", false);
            turnAroundIn = true;
            other.GetComponent<PlayerLogic>().MoveRobUnluckPlayer();
            dollarCountManagerScript.DollarsAdd(valueDollarUnluck, false);
            FindObjectOfType<PoliceSpawner>().SpawnPolice();
            audioSTarget.PlayOneShot(audioClipsRob[1]);
            other.gameObject.GetComponentInChildren<Animator>().SetBool("Steal", false);
            // other.GetComponent<PlayerLogic>().particleMoney.SetActive(true);
            //other.GetComponent<PlayerLogic>().particleMoney.GetComponent<ParticleSystem>().Play(); 
            //other.GetComponent<PlayerLogic>().PlayParticleDollar(); 

            PlayParticleDollar(); 


            currentSlider.gameObject.SetActive(false);
            isRobbed = true;
            return;
        }
        else                                                     // ������� ����������
        {
            other.gameObject.GetComponentInChildren<Animator>().SetBool("Steal", false);
            other.gameObject.GetComponentInChildren<Animator>().SetBool("StealYes", true);


            Invoke("PlayCashSound", 0.5f);

            if (currentType == Types.typeOfTarget.green)
            {
                other.GetComponent<PlayerLogic>().colorchange.ChangeColor();
            }
            isRobbed = true;
            dollarCountManagerScript.DollarsAdd(valueDollarPerson, true);
            dollarCountManagerScript.ShowDollarIconSuccess();
            currentSlider.gameObject.SetActive(false);
            //other.gameObject.GetComponentInChildren<Animator>().SetBool("StealYes", false);


            other.GetComponent<PlayerLogic>().StopAnimPlayer(isRobbed);
            robStage = 2;
           
            //skinPlayer.GetComponent<Animator>().SetBool("Steal", false);
            return;
        }

    }

    void PlayCashSound()
    {
        audioSTarget.PlayOneShot(audioClipsRob[0]);
    }

    public void PlayParticleDollar()
    {
        particleMoney.GetComponent<ParticleSystem>().Play();  // TODO ������� ������ �� ������ � ������
        StartCoroutine(StopParticleDollar());
    }
    IEnumerator StopParticleDollar()
    {
        yield return new WaitForSeconds(1.5f);
        particleMoney.GetComponent<ParticleSystem>().Stop();
    }
}
    
