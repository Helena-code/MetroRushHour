using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPointsLocal : MonoBehaviour
{
    Transform spawnPos;
    float timer;                              //поле таймер - сколько точка уже отображает префаб
    public float timeToStayAtPlatform;        // общее время отображения цели на платформе

    TargetScript currentTargetScript;               // ссылка на скрипт префеба
    public Types.typeOfTarget currentType;    //поле тип префаба - получить из созданного префаба
    bool isRobbed;                            //поле статус префаба - ограблен для зеленых и красных (удачно/неудачно неважно) или истекло время у толпы
    public GameObject currentTarget;
    public SpawnPointsManager spManager;
    int randForCreate;                            // рабочая переменная для рандомности префабов
    public bool isActive;

    private void Awake()
    {
        spawnPos = transform;
        spawnPos.position = transform.position;
        isActive = false;
    }
    private void Start()
    {
        //CreateTarget();    //  метод создания префаба
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

        //    if (currentTargetScript.isRobbed)  //  если префаб ограбили
        //    {
        //        DestroyTarget();
        //    }
        //    if (timer > timeToStayAtPlatform)  //  если таймер истек
        //    {
        //        DestroyTarget();
        //    }
        //}

    }

   public void DestroyTarget()                                                          //  метод уничтожения префаба 
    {
        Debug.Log("Метод дестрой из точки спавна");
        spManager.SummAllTypesofTargets(currentType, false);                      // отправить в менеджера спавнов тип объекта для учета
        currentTargetScript.DestroyTarget();                                     //  - отключения скипта префаба можно вызвать у самого префаба

        //  - прозрачность можно сделать отдельным скриптом из Даниного

        Destroy(currentTarget);                                                 //  - дестрой префаба можно вызвать после завершения прозрачности
        currentTarget = null;
        currentTargetScript = null;
        isActive = false;
    }
   public void CreateTarget()                                                           //  метод создания префаба
    {
        Debug.Log("вызван создание префаба из спавн пойнта");
        currentType = spManager.AskTypeOfNew();           // запросить тип нового объекта у менеджера
        switch (currentType)                       //- выбрать рандомное число от 0 до длины списка префабов
        {
            case Types.typeOfTarget.green:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsGreen.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsGreen[randForCreate]);
                spManager.SummAllTypesofTargets(Types.typeOfTarget.green, true);
                Debug.Log("вызван случай зеленый");
                break;
            case Types.typeOfTarget.red:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsRed.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsRed[randForCreate]);
                spManager.SummAllTypesofTargets(Types.typeOfTarget.red, true);
                Debug.Log("вызван случай красный");
                break;
            case Types.typeOfTarget.yellow:
                randForCreate = Random.Range(0, spManager.PrefabsTargetsYellow.Length);
                currentTarget = Instantiate(spManager.PrefabsTargetsYellow[randForCreate]);
                Debug.Log("вызван случай желтый");
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
        //currentType = currentTargetScript.currentType;    // на всякий случай?
        isActive = true;
        //timer = 0f;
    }


}
