using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeToTalkScript : MonoBehaviour
{
    public enum PlayerState
    {
        TalkStart,
        TalkEnd,
        None,
        CanNotTalk,
    }
    public PlayerState playerState;
    public Types.typeOfTarget currentType;
    //public UnityAction onPlayerLose;
    public Transform GoToTalk;
    public Transform EndToTalk;
    public GameObject player;
    public GameObject iconHide;
    public Slider slider;
    public AudioSource audioSourseCrowd;
    public AudioClip audioClipCrowd;

    PlayerLogic playerScript;
    public float timeCurrent;
    public int time;
    public int maxTime;
    public float timeLeft;
    public float distance;
    public bool usableSpace = true;

    float secondsValueCurrent;
    float timeStart = 6f;
    bool playClip;

    public void StateMachine()
    {
        if (player != null)
        {

            switch (playerState)
            {
                case PlayerState.TalkStart:
                    playerScript.enabled = false;
                    if (Vector3.Distance(player.transform.position, GoToTalk.position) > 0.3f)
                    {
                        player.transform.position = Vector3.MoveTowards(player.transform.position, GoToTalk.position, 2 * Time.deltaTime);
                    }
                    else
                    {
                        usableSpace = true;
                    }

                    break;
                case PlayerState.TalkEnd:
                    BackToEnd();
                    break;
                case PlayerState.CanNotTalk:

                    break;
            }
        }
    }

    public void DestroyTarget()
    {
        if (player != null)
        {
            player.GetComponent<PlayerRunAway>().MoveAway();
            Destroy(this);
        }
    }
    private void Awake()
    {
        slider.gameObject.SetActive(false);
        iconHide.SetActive(false);
    }

    void Start()
    {
        slider.maxValue = maxTime;
        slider.value = maxTime;
        timeLeft = maxTime;
        timeCurrent = timeStart;
        secondsValueCurrent = 0;
        audioSourseCrowd = GetComponent<AudioSource>();
        playClip = true;
        playerState = PlayerState.None;
    }

    void Update()
    {
            StateMachine();
            secondsValueCurrent += Time.deltaTime;
            if (player != null && playerScript != null)
            {
                if (playerState == PlayerState.TalkStart)
                {
                    PlayerInDist();
                }
            }


        // TODO оставлено пока для работы над слайдером
        //if (player != null && player.GetComponent<PlayerLogic>())
        //{
        //    if (Vector3.Distance(player.transform.position, transform.position) <= distance)
        //    {
        //        PlayerInDist();
        //    }
        //}
    }

    void BackToEnd()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, EndToTalk.position, 2 * Time.deltaTime);
        if (Vector3.Distance(player.transform.position, EndToTalk.position) < 0.3f)
        {
            playerScript.enabled = true;
            usableSpace = true;
            playerState = PlayerState.None;
            // TODO добавить обнуление полей игрок и его скрипт? возможно не надо, потому что игрок один и у него запоминается стадия ?
            if (timeLeft < 0)
            {
                playerState = PlayerState.CanNotTalk;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerLogic>())
        {
            iconHide.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerLogic>())
        {
            playerScript = other.GetComponent<PlayerLogic>();
            player = other.gameObject;
            if (Input.GetKeyDown(KeyCode.Space) && usableSpace && timeLeft > 0)
            {
                slider.gameObject.SetActive(true);
                usableSpace = false;
                if (playerState == PlayerState.TalkStart)
                {
                    playerState = PlayerState.TalkEnd;
                }
                if (playerState == PlayerState.None)
                {
                    playerState = PlayerState.TalkStart;
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = null;
        iconHide.SetActive(false);
    }

    // TODO метод не отображает смысл, переименовать или заделить как-то
    void PlayerInDist()
    {

        if (timeLeft > 0)
        {
            StartCoroutine(timer());
        }
        else
        {
            if (playClip)
            {
                PlayClipCrowd();
            }
            playerState = PlayerState.TalkEnd;
        }

    }

    void PlayClipCrowd()
    {
        audioSourseCrowd.PlayOneShot(audioClipCrowd);
        playClip = false;
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        timeLeft = timeLeft - 1 * Time.deltaTime;
        slider.value = timeLeft;
    }
}
