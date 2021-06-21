using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPointsLocal : MonoBehaviour
{
    Transform spawnPos;
    float timer;                              //���� ������ - ������� ����� ��� ���������� ������
    public float timeToStayAtPlatform;        // ����� ����� ����������� ���� �� ���������

    //TargetScript currentTargetScript;               // ������ �� ������ �������
    public Types.typeOfTarget currentType;    //���� ��� ������� - �������� �� ���������� �������
    bool isRobbed;                            //���� ������ ������� - �������� ��� ������� � ������� (������/�������� �������) ��� ������� ����� � �����
    public GameObject currentTarget;
    public SpawnPointsManager spManager;
    int randForCreate;                            // ������� ���������� ��� ����������� ��������
    public bool isActive;
    DestroyTargets destroyScript;

    private void Awake()
    {
        spawnPos = transform;
        spawnPos.position = transform.position;
        isActive = false;
    }
    private void Start()
    {
        //CreateTarget();    //  ����� �������� �������
        //timer = 0f;
    }


    private void Update()
    {
        //if (currentTarget == null)
        //{
        //    Debug.Log("currentTarget = null");
        //    CreateTarget();
        //}
        //else if (currentTarget != null)
        //{
        //    Debug.Log("currentTarget != null");
        //    timer += Time.deltaTime;

        //    if (currentTargetScript.isRobbed)  //  ���� ������ ��������
        //    {
        //        DestroyTarget();
        //    }
        //    if (timer > timeToStayAtPlatform)  //  ���� ������ �����
        //    {
        //        DestroyTarget();
        //    }
        //}

    }

    public void DestroyTarget()                                                          //  ����� ����������� ������� 
    {
        //Debug.Log("����� ������� �� ����� ������");
        //if (currentTargetScript != null)
        //{
        //    Debug.Log("currentTargetScript != null");
        //}

        spManager.SummAllTypesofTargets(currentType, false);                      // ��������� � ��������� ������� ��� ������� ��� �����
        //currentTargetScript.DestroyTarget();                                     //  - ���������� ������ ������� ����� ������� � ������ �������
        destroyScript.DestroyTarget();
        //  - ������������ ����� ������� ��������� �������� �� ��������

        Destroy(currentTarget);                                                 //  - ������� ������� ����� ������� ����� ���������� ������������
        currentTarget = null;
        // currentTargetScript = null;
        destroyScript = null;
         isActive = false;
    }
    public void CreateTarget()                                                           //  ����� �������� �������
    {
        //Debug.Log("������ �������� ������� �� ����� ������");
        currentType = spManager.AskTypeOfNew();                 // ��������� ��� ������ ������� � ���������
        switch (currentType)                                    //- ������� ��������� ����� �� 0 �� ����� ������ ��������
        {
            case Types.typeOfTarget.green:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsGreen.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsGreen[randForCreate]);
                spManager.SummAllTypesofTargets(Types.typeOfTarget.green, true);
                //currentTargetScript = currentTarget.GetComponent<TargetScript>();
                //Debug.Log("������ ������ �������");
                break;
            case Types.typeOfTarget.red:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsRed.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsRed[randForCreate]);
                //currentTargetScript = currentTarget.GetComponent<TargetScript>();
                spManager.SummAllTypesofTargets(Types.typeOfTarget.red, true);

                //Debug.Log("������ ������ �������");
                break;
            case Types.typeOfTarget.yellow:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsYellow.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsYellow[randForCreate]);
                //Debug.Log("������ ������ ������");
                //currentTargetScript = currentTarget.GetComponent<TimeToTalkScript>();
                spManager.SummAllTypesofTargets(Types.typeOfTarget.yellow, true);
                break;
                //case Types.typeOfTarget.green:
                //    randForCreate = Random.Range(0, Types.PrefabsTargetsGreen.Length);
                //    currentTarget = Instantiate(Types.PrefabsTargetsGreen[randForCreate]);
                //    break;
                //case Types.typeOfTarget.red:
                //    randForCreate = Random.Range(0, Types.PrefabsTargetsRed.Length);
                //    currentTarget = Instantiate(Types.PrefabsTargetsRed[randForCreate]);
                //    break;
                //case Types.typeOfTarget.yellow:
                //    randForCreate = Random.Range(0, Types.PrefabsTargetsYellow.Length);
                //    currentTarget = Instantiate(Types.PrefabsTargetsYellow[randForCreate]);
                //    break;
        }

        currentTarget.transform.position = spawnPos.position;
        destroyScript = currentTarget.GetComponent<DestroyTargets>();
        destroyScript.SetType(currentType);
        // currentTargetScript = currentTarget.GetComponent<TargetScript>();
        //if (currentTargetScript != null)
        //{
        //    Debug.Log("currentTargetScript �������");
        //}

        //currentType = currentTargetScript.currentType;    // �� ������ ������?
        isActive = true;
        //timer = 0f;
    }


}
