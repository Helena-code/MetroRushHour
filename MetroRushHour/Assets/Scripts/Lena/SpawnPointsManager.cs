using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public GameObject[] SpawnPointsAll;             //список всех точек спавна
    public GameObject[] PrefabsTargetsAll;          //список всех префабов
    public  GameObject[] PrefabsTargetsGreen;          //список всех префабов     3 зеленых, 4 красных, 4 толпы
    public  GameObject[] PrefabsTargetsRed;          //список всех префабов     3 зеленых, 4 красных, 4 толпы
    public  GameObject[] PrefabsTargetsYellow;          //список всех префабов     3 зеленых, 4 красных, 4 толпы

    int countGreen;
    int countRed;
    int countYellow;

    int addingTemp;                // рабочая переменная для учета суммы всех типов

    private void Awake()
    {
        //  запуск всех точек на сцене через 0,1 секунду по списку 
       // (чтобы не все в один момент появились и совпала idle)
       // еще их надо запустить потому, что иначе все будут зеленые - так по расчету процентов
       // перемешать и включать разные точки, чтобы зеленый распределился равномерно
        //  включение у них скрипта
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
        if (countYellow < 3)                       //если толпы меньше 3, то отправить объект толпа
        {
            SummAllTypesofTargets(Types.typeOfTarget.yellow, true);
            return Types.typeOfTarget.yellow;

        }
        else                        // ЭТОТ КУСОК НАДО ПЕРЕПИСАТЬ
        {
            if ((countGreen / (countGreen + countRed) * 100) < 70)        //посчитать процент зеленых и красных
            {                                                       //если % зеленых меньше 70 отправить рандомного зеленого 
                SummAllTypesofTargets(Types.typeOfTarget.green, true);
                return Types.typeOfTarget.green;
            }
            else
            {
                SummAllTypesofTargets(Types.typeOfTarget.red, true);
                return Types.typeOfTarget.red;                     //иначе отправить рандомного красного
            }
        }

    }

}

