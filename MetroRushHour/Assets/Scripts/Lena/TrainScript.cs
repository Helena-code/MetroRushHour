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
    public float timerForAudioStart;
    public Transform startPoint;
    public AudioClip startTrainSound;
    public AudioClip endTrainSound;
    AudioSource audioSourseTrain;

    Transform trTrain;

    float timerForAudioCurrent;
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
        timerForAudioCurrent = 0f;
        isOnStation = false;
        //destroyT = true;
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
            timerForAudioCurrent += Time.fixedDeltaTime;
            if (timerForAudioCurrent > timerForAudioStart)
            {
                if (arrivalAtStation)
                {
                    currentSpeed -= stopCoeff;
                }
                else if (departureFromStation)
                {
                    currentSpeed += stopCoeff;
                }
                trTrain.Translate(Vector3.right * (currentSpeed) * Time.fixedDeltaTime);
            }
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
            

            if (destroyT)
            {
                DestroyTargets();
            }

            if (timerStayCurrent > timerStay)                                 // ����� ������ ������� ����������
            {

                if (playS)
                {
                    PlaySoundLeaveStation();
                }
                timerForAudioCurrent = 0f;
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
        if (other.GetComponent<BorderForTrain>() != null)
        {
            transform.position = startPoint.position;
            currentSpeed = 0f;
        }
    }

    void PlaySoundLeaveStation()
    {
        audioSourseTrain.PlayOneShot(endTrainSound);         // �������� ���� ������������ ������
        playS = false;
    }

    void DestroyTargets()
    {
        StartCoroutine(spManager.DestroyTargets());                   // ��������� ������ � ����� ��������� ������� � ������� ������� ����� ����������
        destroyT = false;
    }

}
