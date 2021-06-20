using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] SpawnPointsAll;             //������ ���� ����� ������
    //public GameObject[] PrefabsTargetsAll;          //������ ���� �������� ���������� �� ���������
    public GameObject[] PrefabsTargetsGreen;             // 3 �������
    public GameObject[] PrefabsTargetsRed;               // 4 �������
    public GameObject[] PrefabsTargetsYellow;            // 2 �����

    public float timeToSpawn = 1.9f;                    //  ����� ����� �������� ���� ����� �� ����� 

    int countGreen;
    int countRed;
    int countYellow;

    int addingTemp;                                             // ������� ���������� ��� ����� ����� ���� �����
    int[] testmas1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };                  // ������ 1 ��� ��������� ���������� ������� - ������������ ���
    float[] testmas2 = new float[10];                             // ������ 2 ��� ��������� ���������� ������� - ������������ ���



    public IEnumerator CreateTargets()
    {
        //foreach (var item in SpawnPointsAll)
        //{
        //    if (!item.GetComponent<SpawnPointsLocal>().isActive)
        //    {
        //        item.GetComponent<SpawnPointsLocal>().CreateTarget();
        //        yield return new WaitForSeconds(timeToSpawn);                
        //    }
        //}

        for (int i = 0; i < testmas1.Length; i++)
        {
            SpawnPointsAll[testmas1[i]].GetComponent<SpawnPointsLocal>().CreateTarget();
            yield return new WaitForSeconds(timeToSpawn);
        }


    }

    public IEnumerator DestroyTargets()
    {
        //foreach (var item in SpawnPointsAll)
        //{
        //    if (!item.GetComponent<SpawnPointsLocal>().isActive)
        //    {
        //        item.GetComponent<SpawnPointsLocal>().DestroyTarget();
        //        yield return new WaitForSeconds(timeToSpawn);
        //    }
        //}
        for (int i = 0; i < testmas1.Length; i++)
        {
            SpawnPointsAll[testmas1[i]].GetComponent<SpawnPointsLocal>().DestroyTarget();
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    private void Awake()
    {
        // ������������ ������ �� ������

        // (����� �� ��� � ���� ������ ��������� � ������� idle)
        // ��� �� ���� ��������� ������, ��� ����� ��� ����� ������� - ��� �� ������� ���������
        // ���������� � �������� ������ �����, ����� ������� ������������� ����������
        //  ��������� � ��� �������

        for (int i = 0; i < testmas2.Length; i++)
        {
            testmas2[i] = UnityEngine.Random.Range(0f, 1f);
        }
        Array.Sort(testmas2, testmas1);
    }

    private void Start()
    {
        //Array.Sort(testmas);

        //for (int i = 0; i < testmas2.Length; i++)
        //{
        //    Debug.Log("������ testmas2" + testmas2[i]);
        //}
        //for (int i = 0; i < testmas1.Length; i++)
        //{
        //    Debug.Log("������ testmas1" + testmas1[i]);
        //}
        //Debug.Log("������ " + testmas1);//[0] + " " + testmas1[1] + " " + testmas1[2]);

        // ����������� ����� ��� ������� ��������

        // ��� �������� ����� �������� ��� ������������ ��������� ������
        // ��� ������ ���������� �� ������

    }


    public void SummAllTypesofTargets(Types.typeOfTarget t, bool adding)            // ����� �������� ���������� ����� ����� �� �����
    {

        if (adding)
        {
            addingTemp = +1;
        }
        else addingTemp = -1;

        switch (t)
        {
            case Types.typeOfTarget.green:
                countGreen += addingTemp;
                break;
            case Types.typeOfTarget.red:
                countRed += addingTemp;
                break;
            case Types.typeOfTarget.yellow:
                countYellow += addingTemp;
                break;

        }
    }

    public Types.typeOfTarget AskTypeOfNew()
    {
        if (countYellow <= 2)                       //���� ����� ������ 3, �� ��������� ������ �����
        {
            // SummAllTypesofTargets(Types.typeOfTarget.yellow, true);
            //Debug.Log("������� �����");
            return Types.typeOfTarget.yellow;

        }
        else                        // ���� ����� ���� ����������
        {
            if (countGreen == 0)
            {
                //SummAllTypesofTargets(Types.typeOfTarget.green, true);
                return Types.typeOfTarget.green;

            }
            else
            {
                if ((countGreen / (countGreen + countRed) * 100) < 50)          //��������� ������� ������� � �������
                {                                                               //���� % ������� ������ 70 ��������� ���������� �������� 
                    //SummAllTypesofTargets(Types.typeOfTarget.green, true);
                    return Types.typeOfTarget.green;
                }
                else
                {
                    //SummAllTypesofTargets(Types.typeOfTarget.red, true);
                    return Types.typeOfTarget.red;                             //����� ��������� ���������� ��������
                }
            }
        }

    }

}

