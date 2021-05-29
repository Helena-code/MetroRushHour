using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeToTalkScript : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityAction onPlayerLose;


    public enum PlayerState
    {
        TalkStart,
        TalkEnd,
        None,
    }
    public PlayerState playerState = PlayerState.TalkEnd;

    public int time;
    public Transform GoToTalk;
    public Transform EndToTall;

    public Slider slider;

    float timeStart = 6f;
    public float timeCurrent;
    //float secondsValue = 2f;
    float secondsValueCurrent;

    public int maxTime;
    public float timeLeft;

    public GameObject player;
    public TestPlayerScript testPlayerScript;

    public float distance;

    public bool usableSpace = true;

    public void StateMachine()
    {
        if (player !=null) {
            switch (playerState)
            {

                case PlayerState.TalkStart:
                    FindObjectOfType<TestPlayerScript>().enabled =  false;
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
                    backToend();
                    break;
            }
        }
    }
    void backToend()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, EndToTall.position, 2 * Time.deltaTime);
        if (Vector3.Distance(player.transform.position, EndToTall.position) < 0.3f)
        {
            FindObjectOfType<TestPlayerScript>().enabled = true;
            usableSpace = true;
            playerState = PlayerState.None;
        }
    }
    void Start()
    {
        testPlayerScript = GetComponent<TestPlayerScript>();
        slider.maxValue = maxTime;
        slider.value = maxTime;
        timeLeft = maxTime;
        timeCurrent = timeStart;
        secondsValueCurrent = 0;
        
    }

    private void OnTriggerStay(Collider other)
    {
        player = other.gameObject;
        if (player.GetComponent<TestPlayerScript>())
        {
            if (Input.GetKeyDown(KeyCode.Space) && usableSpace && timeLeft > 0)
            {
                Debug.Log("Input.GetKeyDown(KeyCode.Space)");
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
    }

    void PlayerInDist()
    {
       
        if (timeLeft > 0) {
            StartCoroutine(timer());
            
            
        }
        else { 
            playerState = PlayerState.TalkEnd;
        }
        
    }
    void Update()
    {
        StateMachine();
        secondsValueCurrent += Time.deltaTime;
        if (player != null && player.GetComponent<TestPlayerScript>()) {
            if (Vector3.Distance(player.transform.position, transform.position) <= distance)
            {
                PlayerInDist();
            }
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        timeLeft = timeLeft - 1* Time.deltaTime;
        slider.value = timeLeft;
    }
}
