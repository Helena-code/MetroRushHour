using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliceSpawner : MonoBehaviour
{
    public float spawningPositionX;
    public GameObject player;
    public GameObject police;
    public Image alarmSign;
    public GameObject alarmSignLeft;
    public GameObject alarmSignRight;

    Vector3 playerPosition;

    // TODO  ”ƒ¿À»“‹ œŒ—À≈ “≈—“»–Œ¬¿Õ»ﬂ
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnPolice();
        //}
    }


    public void SpawnPolice()
    {
        if (!FindObjectOfType<PoliceMovement>())
        {
            playerPosition = player.transform.position;
            if (playerPosition.x > 0)
            {
                Instantiate(police, new Vector3(-spawningPositionX, playerPosition.y, playerPosition.z), Quaternion.Euler(0f, 90f, 0f));
                ActivateAlarmSign(alarmSignLeft);

            }
            else
            {
                Instantiate(police, new Vector3(spawningPositionX, playerPosition.y, playerPosition.z), Quaternion.Euler(0f, -90f, 0f));
                ActivateAlarmSign(alarmSignRight);
            }
        }
    }

    void ActivateAlarmSign(GameObject go)
    {
        alarmSign.transform.position = go.transform.position;
        alarmSign.gameObject.SetActive(true);
        StartCoroutine(HideAlarmSign());
    }

    IEnumerator HideAlarmSign()
    {
        yield return new WaitForSeconds(2f);
        alarmSign.gameObject.SetActive(false);
    }
}
