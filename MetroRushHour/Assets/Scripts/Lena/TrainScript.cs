using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public SpawnPointsManager spManager;

    bool isOnStation;              //поле состояние поезда isOnStation
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
        //    //едет с уменьшающейся скоростью
        //    currentSpeed -= stopCoeff;
        //    trTrain.Translate(Vector3.right * (currentSpeed) * Time.deltaTime);
        //    //  trTrain.Translate(Vector3.right * (speed ) * Time.deltaTime);
        //}

        if (arrivalAtStation)
        {
            if (currentSpeed <= -stopCoeff * 8f)
            {
                isOnStation = true;              // поменять состояние поезда на станции тру
                currentSpeed = 0f;               // отключить движение
                arrivalAtStation = false;
                departureFromStation = true;
            }
        }

        if (isOnStation)
        {
            timerStayCurrent += Time.deltaTime;                            // включить таймер стоянки

            //if (destroyT)
            //{
            //    Invoke("DestroyTargets", 2f);
            //}

            if (timerStayCurrent > timerStay)                                 // когда таймер стоянки закончится
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
        // стартовать таймер для подъезжания - нужен видимо отдельный метод
        // наращивать скорость - может булева перменная типа isRun? и когда она активна то движение работает

    }
    private void OnTriggerEnter(Collider other)
    {
        // когда поезд дошел до определенной границы по х
        // переместить его в начальную точку - можно повесить коллаидер и чекать, что поезд въехал в него
        // выключить всю скорость и все остальные переменные на фолс
        if (other.GetComponent<BorderForTrain>() != null)
        {
            transform.position = startPoint.position;
            currentSpeed = 0f;
        }
    }

    void PlaySoundLeaveStation()
    {
        audioSourseTrain.PlayOneShot(endTrainSound);         // включить звук отъезжающего поезда
        playS = false;
    }

    void DestroyTargets()
    {
        //Debug.Log("Запуск дестроя таргетов из поезда");
        StartCoroutine(spManager.DestroyTargets());                   // отправить запрос в метод менеджера спавнов о запуске дестроя точек поочередно
        destroyT = false;
    }

}
