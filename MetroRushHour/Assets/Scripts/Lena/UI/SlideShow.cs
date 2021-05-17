using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShow : MonoBehaviour
{
    public Image[] imagesScenes = new Image[5] ;
    //public Image im1;
    //public Image im2;
    float speed = 0.25f;
    Color startColor;
    Color middleColor;
    Color currentColor;
    bool middlePos;
    bool im1Done;
    bool im2Done;
   public float timeToChange = 4f;
    float currentTimeToChange;
    float currentTime;
    int numberOfImage = 0;

    Image currentImage;

    private void Awake()
    {
        startColor = new Color(0f, 0f, 0f, 255f);
        //startColor = new Color(255f, 255f, 255f, 0f);
        middleColor = new Color(255f, 255f, 255f, 255f);
        //im1.GetComponent<Image>().color = startColor;
        currentColor = middleColor;
        //Debug.Log("currentColor " + currentColor);
        currentImage = imagesScenes[ numberOfImage];

    }
    private void Update()
    {
        //GetComponent<MeshRenderer>().material.color = Color.Lerp(GetComponent<MeshRenderer>().material.color, endColor, Time.deltaTime / 2);
        //Debug.Log("imColor " + im1.GetComponent<Image>().color);

        //im2.GetComponent<Image>().color = new Color(im2.GetComponent<Image>().color.r, im2.GetComponent<Image>().color.g, im2.GetComponent<Image>().color.b, im2.GetComponent<Image>().color.a+0.25f* Time.deltaTime);
        //im2.GetComponent<Image>().color = new Color(im2.GetComponent<Image>().color.r, im2.GetComponent<Image>().color.g, im2.GetComponent<Image>().color.b, im2.GetComponent<Image>().color.a-0.25f* Time.deltaTime);
        //im2.color = new Color(im2.color.r, im2.color.g, im2.color.b, im2.color.a-Time.deltaTime*speed);

        //if (currentImage.color.a < 0.1f)
        //{
        //    currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, currentImage.color.a + Time.deltaTime * speed);
        //}
        //else if (currentImage.color.a > 0.9f)
        //{
        //    currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, currentImage.color.a - Time.deltaTime * speed);
        //}


        currentTimeToChange += Time.deltaTime;
        if (Mathf.Abs(currentTime - timeToChange) < 0.05f)
        {
            currentImage = imagesScenes[numberOfImage + 1];
        }

        currentTime += Time.deltaTime;
        if (currentTime > timeToChange/2)
        {
            currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, currentImage.color.a - Time.deltaTime * speed);
            
        }
        else
        {
            currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, currentImage.color.a + Time.deltaTime * speed);
        }


    }
}

//////////////////////
//if (!im1Done)
//{
//    //Debug.Log("работает  !middle");
//    im1.GetComponent<Image>().color = Color.Lerp(im1.GetComponent<Image>().color, middleColor, Time.deltaTime * speed);
//    //Debug.Log("currentColor " + currentColor);
//    //Debug.Log("imColor " + im1.GetComponent<Image>().color);
//    //if (im1.GetComponent<Image>().color.a > 0.9f)
//    if (im1.GetComponent<Image>().color.r > 0.9f)
//    {
//        //Debug.Log("Зашла в if color middle");
//        //currentColor = startColor;
//        //Debug.Log("currentColor " + currentColor);
//        im1Done = true;
//    }
//}
// if (im1Done)
//{
//    im2.GetComponent<Image>().color = Color.Lerp(im2.GetComponent<Image>().color, middleColor, Time.deltaTime * speed);
//}


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


