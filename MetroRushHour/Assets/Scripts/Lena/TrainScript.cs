using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public SpawnPointsManager spManager;

    bool isOnStation;              //���� ��������� ������ isOnStation
    public float currentSpeed;
    public float speedStart;
    public float stopCoeff;
    public float timerStay;
    public float AudioSynchStart;
    public float AudioSynchEnd;
    public Transform startPoint;
    public AudioClip startTrainSound;
    public AudioClip endTrainSound;
    AudioSource audioSourseTrain;

    Transform trTrain;

    float timerForAudioSynch;
    float timerStayCurrent;

    bool destroyT;
    bool playS;
    bool isRun;
    bool arrivalAtStation;
    bool departureFromStation;

    private void Awake()
    {
        audioSourseTrain = GetComponent<AudioSource>();
        audioSourseTrain.PlayOneShot(startTrainSound);
        trTrain = GetComponent<Transform>();
        trTrain.position = startPoint.position;
        currentSpeed = speedStart;
        timerForAudioSynch = 0f;
        timerStayCurrent = 0f;
        isOnStation = false;
        destroyT = true;
        playS = true;
        arrivalAtStation = true;
        departureFromStation = false;
    }
    void Start()
    {
        StartCoroutine(spManager.CreateTargets());
    }

    private void FixedUpdate()
    {
        if (!isOnStation)
        {
            timerForAudioSynch += Time.fixedDeltaTime;

            if (arrivalAtStation)
            {
                if (timerForAudioSynch > AudioSynchStart)
                {
                    currentSpeed -= stopCoeff;
                    trTrain.Translate(Vector3.right * (currentSpeed) * Time.fixedDeltaTime);
                }
            }
            else if (departureFromStation)
            {
                if (timerForAudioSynch > AudioSynchEnd)
                {
                    currentSpeed += stopCoeff*0.5f;
                    trTrain.Translate(Vector3.right * (currentSpeed) * Time.fixedDeltaTime);
                }
            }



            //if (timerForAudioSynch > AudioSynchStart)
            //{
            //    if (arrivalAtStation)
            //    {
            //        currentSpeed -= stopCoeff;
            //    }
            //    else if (departureFromStation)
            //    {
            //        currentSpeed += stopCoeff;
            //    }
            //    trTrain.Translate(Vector3.right * (currentSpeed) * Time.fixedDeltaTime);
            //}
        }
    }

    void Update()
    {
        //timerForAudio += Time.deltaTime;
        //if (timerForAudio > 18f)
        //{
        //    if (!isOnStation)
        //    {
        //        currentSpeed -= stopCoeff;
        //        trTrain.Translate(Vector3.right * (currentSpeed) * Time.deltaTime);
        //    }
        //}

        //if (!isOnStation)
        //{
        //    //���� � ������������� ���������
        //    currentSpeed -= stopCoeff;
        //    trTrain.Translate(Vector3.right * (currentSpeed) * Time.deltaTime);
        //    //  trTrain.Translate(Vector3.right * (speed ) * Time.deltaTime);
        //}

        if (arrivalAtStation)
        {
            if (currentSpeed <= -stopCoeff * 8f)
            {
                isOnStation = true;              // �������� ��������� ������ �� ������� ���
                currentSpeed = 0f;               // ��������� ��������
                arrivalAtStation = false;
                departureFromStation = true;
            }
        }

        if (isOnStation)
        {
            timerStayCurrent += Time.deltaTime;                            // �������� ������ �������

            //if (destroyT)
            //{
            //    Invoke("DestroyTargets", 2f);
            //}

            if (timerStayCurrent > timerStay)                                 // ����� ������ ������� ����������
            {

                if (playS)
                {
                    PlaySoundLeaveStation();
                }
                if (destroyT)
                {
                    DestroyTargets();
                }
                timerForAudioSynch = 0f;
                timerStayCurrent = 0f;
                isOnStation = false;

            }
        }
        // ���������� ������ ��� ����������� - ����� ������ ��������� �����
        // ���������� �������� - ����� ������ ��������� ���� isRun? � ����� ��� ������� �� �������� ��������

    }
    private void OnTriggerEnter(Collider other)
    {
        // ����� ����� ����� �� ������������ ������� �� �
        // ����������� ��� � ��������� ����� - ����� �������� ��������� � ������, ��� ����� ������ � ����
        // ��������� ��� �������� � ��� ��������� ���������� �� ����
        if (other.gameObject.GetComponent<BorderForTrain>() != null)
        {
            Debug.Log("���������� ������� ��� ������");
            transform.position = startPoint.position;
            currentSpeed = 0f;
            //GetComponent<TrainHelper>().
            audioSourseTrain.PlayOneShot(startTrainSound);
            timerForAudioSynch = 0f;
            timerStayCurrent = 0f;
            isOnStation = false;
            destroyT = true;
            playS = true;
            arrivalAtStation = true;
            departureFromStation = false;
            currentSpeed = speedStart;
            StartCoroutine(spManager.CreateTargets());
        }
    }

    void PlaySoundLeaveStation()
    {
        audioSourseTrain.PlayOneShot(endTrainSound);         // �������� ���� ������������ ������
        playS = false;
    }

    void DestroyTargets()
    {
        //Debug.Log("������ ������� �������� �� ������");
        StartCoroutine(spManager.DestroyTargets());                   // ��������� ������ � ����� ��������� ������� � ������� ������� ����� ����������
        destroyT = false;
    }

}
