using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] SpawnPointsAll;             //������ ���� ����� ������
    public GameObject[] PrefabsTargetsAll;          //������ ���� ��������
    public  GameObject[] PrefabsTargetsGreen;          //������ ���� ��������     3 �������, 4 �������, 4 �����
    public  GameObject[] PrefabsTargetsRed;          //������ ���� ��������     3 �������, 4 �������, 4 �����
    public  GameObject[] PrefabsTargetsYellow;          //������ ���� ��������     3 �������, 4 �������, 4 �����

    int countGreen;
    int countRed;
    int countYellow;

    int addingTemp;                // ������� ���������� ��� ����� ����� ���� �����

    private void Awake()
    {
        //  ������ ���� ����� �� ����� ����� 0,1 ������� �� ������ 
       // (����� �� ��� � ���� ������ ��������� � ������� idle)
       // ��� �� ���� ��������� ������, ��� ����� ��� ����� ������� - ��� �� ������� ���������
       // ���������� � �������� ������ �����, ����� ������� ������������� ����������
        //  ��������� � ��� �������
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
        if (countYellow < 3)                       //���� ����� ������ 3, �� ��������� ������ �����
        {
            SummAllTypesofTargets(Types.typeOfTarget.yellow, true);
            return Types.typeOfTarget.yellow;

        }
        else                        // ���� ����� ���� ����������
        {
            if ((countGreen / (countGreen + countRed) * 100) < 70)        //��������� ������� ������� � �������
            {                                                       //���� % ������� ������ 70 ��������� ���������� �������� 
                SummAllTypesofTargets(Types.typeOfTarget.green, true);
                return Types.typeOfTarget.green;
            }
            else
            {
                SummAllTypesofTargets(Types.typeOfTarget.red, true);
                return Types.typeOfTarget.red;                     //����� ��������� ���������� ��������
            }
        }

    }

}

