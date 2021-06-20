using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveScript : MonoBehaviour
{
    public float point1;
    public float point2;
    public float speed;
    float coef = -1f;
    public Transform point3;
    Transform transformCrowd;
    Animator anim;
   public GameObject skin;
    void Start()
    {
        transformCrowd = GetComponent<Transform>();
        //anim.GetComponentInChildren<Animator>();
        //anim.SetBool("Walk", true);
        skin.GetComponent<Animator>().SetBool("Walk", true);
    }


    void Update()
    {
        Vector3 currentMovement = Vector3.right * Time.deltaTime;
        transformCrowd.Translate(currentMovement*coef);
        if (transformCrowd.position.x < point1 || transformCrowd.position.x > point2)
        {
            coef *= -1;
            skin.transform.Rotate(new Vector3(0f, 180f, 0f));      // убрать создание вектора , добавить переменную в поля
        }
        
    }
}
