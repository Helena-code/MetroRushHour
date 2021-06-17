using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] SpawnPointsAll;             //������ ���� ����� ������
    //public GameObject[] PrefabsTargetsAll;          //������ ���� �������� ���������� �� ���������
    public  GameObject[] PrefabsTargetsGreen;             // 3 �������
    public  GameObject[] PrefabsTargetsRed;               // 4 �������
    public  GameObject[] PrefabsTargetsYellow;            // 2 �����

    int countGreen;
    int countRed;
    int countYellow;

    int addingTemp;                // ������� ���������� ��� ����� ����� ���� �����
    int randomTemp;                // ������� ���������� ��� ���������� ������ ����� �������

    private void Awake()
    {
        
    }

    private void Start()
    {
        for (int i = 0; i < SpawnPointsAll.Length; i++)
        {
            //Debug.Log("����� ����� ������ + " + i);
            // ���� ����� �� �������
            if (!SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().isActive)
            {
            SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().CreateTarget();
            //Invoke("SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().CreateTarget()",0.5f);
            }


        }
        //  ������ ���� ����� �� ����� ����� 0,1 ������� �� ������ 
        // (����� �� ��� � ���� ������ ��������� � ������� idle)
        // ��� �� ���� ��������� ������, ��� ����� ��� ����� ������� - ��� �� ������� ���������
        // ���������� � �������� ������ �����, ����� ������� ������������� ����������
        //  ��������� � ��� �������

        // ������������ ������ �� ������ ��� ������ � �������� ��������
        // �������� - ���������� � ����� ������ �� �������� ���� � ����������� �������
        // ��������� ����� �� ������� ������� ���������� �����
        // ���� �����, ��������� ��������
        // ���� ���, �� ����������� ������� � ������������� �������� � 2 �������

        // ����������� ����� ��� ������� ��������

        // ��� �������� ����� �������� ��� ������������ ��������� ������
        // ��� ������ ���������� �� ������

    }
    public void CreateTargets(int ind)
    {
        //SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().CreateTarget()
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
                if ((countGreen / (countGreen + countRed) * 100) < 70)        //��������� ������� ������� � �������
                {                                                       //���� % ������� ������ 70 ��������� ���������� �������� 
                    //SummAllTypesofTargets(Types.typeOfTarget.green, true);
                    return Types.typeOfTarget.green;
                }
                else
                {
                    //SummAllTypesofTargets(Types.typeOfTarget.red, true);
                    return Types.typeOfTarget.red;                     //����� ��������� ���������� ��������
                }
            }
        }

    }

}

