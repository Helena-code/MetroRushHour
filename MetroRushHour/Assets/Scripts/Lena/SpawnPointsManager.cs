using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] SpawnPointsAll;             //список всех точек спавна
    //public GameObject[] PrefabsTargetsAll;          //список всех префабов персонажей на платформе
    public GameObject[] PrefabsTargetsGreen;             // 3 зеленых
    public GameObject[] PrefabsTargetsRed;               // 4 красных
    public GameObject[] PrefabsTargetsYellow;            // 2 толпы

    public float timeToSpawn = 1.9f;                    //  время между запуском всех точек на сцене 

    int countGreen;
    int countRed;
    int countYellow;

    int addingTemp;                                             // рабочая переменная для учета суммы всех типов
    int[] testmas1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };                  // массив 1 для рандомной сортировки спавнов - используются оба
    float[] testmas2 = new float[10];                             // массив 2 для рандомной сортировки спавнов - используются оба



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
        // перемешиваем массив на страте

        // (чтобы не все в один момент появились и совпала idle)
        // еще их надо запустить потому, что иначе все будут зеленые - так по расчету процентов
        // перемешать и включать разные точки, чтобы зеленый распределился равномерно
        //  включение у них скрипта

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
        //    Debug.Log("массив testmas2" + testmas2[i]);
        //}
        //for (int i = 0; i < testmas1.Length; i++)
        //{
        //    Debug.Log("массив testmas1" + testmas1[i]);
        //}
        //Debug.Log("массив " + testmas1);//[0] + " " + testmas1[1] + " " + testmas1[2]);

        // аналогичная схема для дестроя объектов

        // обе карутины будут работать при срабатывании состояния поезда
        // или вообще вызываться из поезда

    }


    public void SummAllTypesofTargets(Types.typeOfTarget t, bool adding)            // метод подсчета количества типов целей на сцене
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
        if (countYellow <= 2)                       //если толпы меньше 3, то отправить объект толпа
        {
            // SummAllTypesofTargets(Types.typeOfTarget.yellow, true);
            //Debug.Log("Вернули толпу");
            return Types.typeOfTarget.yellow;

        }
        else                        // ЭТОТ КУСОК НАДО ПЕРЕПИСАТЬ
        {
            if (countGreen == 0)
            {
                //SummAllTypesofTargets(Types.typeOfTarget.green, true);
                return Types.typeOfTarget.green;

            }
            else
            {
                if ((countGreen / (countGreen + countRed) * 100) < 50)          //посчитать процент зеленых и красных
                {                                                               //если % зеленых меньше 70 отправить рандомного зеленого 
                    //SummAllTypesofTargets(Types.typeOfTarget.green, true);
                    return Types.typeOfTarget.green;
                }
                else
                {
                    //SummAllTypesofTargets(Types.typeOfTarget.red, true);
                    return Types.typeOfTarget.red;                             //иначе отправить рандомного красного
                }
            }
        }

    }

}

