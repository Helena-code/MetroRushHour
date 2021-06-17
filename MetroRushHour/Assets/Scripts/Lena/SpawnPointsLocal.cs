using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPointsLocal : MonoBehaviour
{
    Transform spawnPos;
    float timer;                              //���� ������ - ������� ����� ��� ���������� ������
    public float timeToStayAtPlatform;        // ����� ����� ����������� ���� �� ���������

    TargetScript currentTargetScript;               // ������ �� ������ �������
    public Types.typeOfTarget currentType;    //���� ��� ������� - �������� �� ���������� �������
    bool isRobbed;                            //���� ������ ������� - �������� ��� ������� � ������� (������/�������� �������) ��� ������� ����� � �����
    public GameObject currentTarget;
    public SpawnPointsManager spManager;
    int randForCreate;                            // ������� ���������� ��� ����������� ��������
    public bool isActive;

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
        Debug.Log("����� ������� �� ����� ������");
        spManager.SummAllTypesofTargets(currentType, false);                      // ��������� � ��������� ������� ��� ������� ��� �����
        currentTargetScript.DestroyTarget();                                     //  - ���������� ������ ������� ����� ������� � ������ �������

        //  - ������������ ����� ������� ��������� �������� �� ��������

        Destroy(currentTarget);                                                 //  - ������� ������� ����� ������� ����� ���������� ������������
        currentTarget = null;
        currentTargetScript = null;
        isActive = false;
    }
   public void CreateTarget()                                                           //  ����� �������� �������
    {
        Debug.Log("������ �������� ������� �� ����� ������");
        currentType = spManager.AskTypeOfNew();           // ��������� ��� ������ ������� � ���������
        switch (currentType)                       //- ������� ��������� ����� �� 0 �� ����� ������ ��������
        {
            case Types.typeOfTarget.green:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsGreen.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsGreen[randForCreate]);
                spManager.SummAllTypesofTargets(Types.typeOfTarget.green, true);
                Debug.Log("������ ������ �������");
                break;
            case Types.typeOfTarget.red:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsRed.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsRed[randForCreate]);
                spManager.SummAllTypesofTargets(Types.typeOfTarget.red, true);
                Debug.Log("������ ������ �������");
                break;
            case Types.typeOfTarget.yellow:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsYellow.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsYellow[randForCreate]);
                Debug.Log("������ ������ ������");
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

        currentTargetScript = currentTarget.GetComponent<TargetScript>();
        //currentType = currentTargetScript.currentType;    // �� ������ ������?
        isActive = true;
        //timer = 0f;
    }


}
