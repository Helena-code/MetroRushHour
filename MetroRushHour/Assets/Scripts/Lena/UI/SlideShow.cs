using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    public Image im1;
    public Image im2;
    public float speed;
    Color startColor;
    Color middleColor;
    Color currentColor;
    bool middlePos;
    bool im1Done;
    bool im2Done;

    private void Awake()
    {
        startColor = new Color(0f, 0f, 0f, 255f);
        //startColor = new Color(255f, 255f, 255f, 0f);
        middleColor = new Color(255f, 255f, 255f, 255f);
        //im1.GetComponent<Image>().color = startColor;
        currentColor = middleColor;
        //Debug.Log("currentColor " + currentColor);
    }
    private void Update()
    {
        //GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        //Debug.Log("imColor " + im1.GetComponent<Image>().color);

        if (!im1Done)
        {
            //Debug.Log("работает  !middle");
            im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, middleColor, Time.deltaTime * speed);
            //Debug.Log("currentColor " + currentColor);
            //Debug.Log("imColor " + im1.GetComponent<Image>().color);
            //if (im1.GetComponent<Image>().color.a > 0.9f)
            if (im1.GetComponent<Image>().color.r > 0.9f)
            {
                //Debug.Log("Зашла в if color middle");
                //currentColor = startColor;
                //Debug.Log("currentColor " + currentColor);
                im1Done = true;
            }
        }
         if (im1Done)
        {
            im2.GetComponent<Image>().color = Color.Lerp(im2.GetComponent<Image>().color, middleColor, Time.deltaTime * speed);
        }


        //if (!middlePos)
        //{
        //    Debug.Log("работает  !middle");
        //    im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, middleColor, Time.deltaTime * speed);
        //    //Debug.Log("currentColor " + currentColor);
        //    //Debug.Log("imColor " + im1.GetComponent<Image>().color);
        //    //if (im1.GetComponent<Image>().color.a > 0.9f)
        //    if (im1.GetComponent<Image>().color.r > 0.9f)
        //    {
        //        Debug.Log("Зашла в if color middle");
        //        //currentColor = startColor;
        //        //Debug.Log("currentColor " + currentColor);
        //        middlePos = true;
        //    }
        //}
        //else if (middlePos)
        //{
        //    Debug.Log("работает  middle");
        //    im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, startColor, Time.deltaTime * speed);
        //}

        //im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, currentColor, Time.deltaTime * speed);
        //Debug.Log("currentColor " + currentColor);
        //Debug.Log("imColor " + im1.GetComponent<Image>().color);
        //if (im1.GetComponent<Image>().color.a > 0.9f)
        //{
        //    Debug.Log("Зашла в if color middle");
        //    currentColor = startColor;
        //    Debug.Log("currentColor " + currentColor);
        //}

        //if (im1.GetComponent<Image>().color.a < 0.9f)
        //{
        //    im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, middleColor, Time.deltaTime * speed);
        //} else if (im1.GetComponent<Image>().color.a > 0.9f)
        //{
        //    im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, startColor, Time.deltaTime * speed);
        //}


    }
}
