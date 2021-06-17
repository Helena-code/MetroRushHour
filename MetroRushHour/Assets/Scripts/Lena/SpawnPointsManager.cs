using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] SpawnPointsAll;             //список всех точек спавна
    //public GameObject[] PrefabsTargetsAll;          //список всех префабов персонажей на платформе
    public  GameObject[] PrefabsTargetsGreen;             // 3 зеленых
    public  GameObject[] PrefabsTargetsRed;               // 4 красных
    public  GameObject[] PrefabsTargetsYellow;            // 2 толпы

    int countGreen;
    int countRed;
    int countYellow;

    int addingTemp;                // рабочая переменная для учета суммы всех типов
    int randomTemp;                // рабочая переменная для рандомного вызова спавн пойнтов

    private void Awake()
    {
        
    }

    private void Start()
    {
        for (int i = 0; i < SpawnPointsAll.Length; i++)
        {
            //Debug.Log("обход точек спавна + " + i);
            // пока вызов по порядку
            if (!SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().isActive)
            {
            SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().CreateTarget();
            //Invoke("SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().CreateTarget()",0.5f);
            }


        }
        //  запуск всех точек на сцене через 0,1 секунду по списку 
        // (чтобы не все в один момент появились и совпала idle)
        // еще их надо запустить потому, что иначе все будут зеленые - так по расчету процентов
        // перемешать и включать разные точки, чтобы зеленый распределился равномерно
        //  включение у них скрипта

        // перемешиваем массив на страте или эвейке и вызываем карутину
        // карутина - отправляет в пойнт запрос на создание цели и увеличивает счетчик
        // проверяет равен ли счетчик размеру количества точек
        // если равен, прерывает карутину
        // если нет, то увеличивает счетчик и устанавливает задержку в 2 секунды

        // аналогичная схема для дестроя объектов

        // обе карутины будут работать при срабатывании состояния поезда
        // или вообще вызываться из поезда

    }
    public void CreateTargets(int ind)
    {
        //SpawnPointsAll[i].GetComponent<SpawnPointsLocal>().CreateTarget()
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
                if ((countGreen / (countGreen + countRed) * 100) < 70)        //посчитать процент зеленых и красных
                {                                                       //если % зеленых меньше 70 отправить рандомного зеленого 
                    //SummAllTypesofTargets(Types.typeOfTarget.green, true);
                    return Types.typeOfTarget.green;
                }
                else
                {
                    //SummAllTypesofTargets(Types.typeOfTarget.red, true);
                    return Types.typeOfTarget.red;                     //иначе отправить рандомного красного
                }
            }
        }

    }

}

