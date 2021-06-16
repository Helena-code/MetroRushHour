using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSSSSSSSSSSSScript : MonoBehaviour
{
    //public Image im1;
    //public Image im2;
    float speed = 0.25f;
    Color startColor;
    Color middleColor;
    Color currentColor;
    public float timeToChange = 4f;
    float currentTimeToChange;
    float currentTime;

    Image currentImage;

    private void Awake()
    {
        startColor = new Color(0f, 0f, 0f, 255f);
        //startColor = new Color(255f, 255f, 255f, 0f);
        middleColor = new Color(255f, 255f, 255f, 255f);
        //im1.GetComponent<Image>().color = startColor;
        currentColor = middleColor;
        //Debug.Log("currentColor " + currentColor);
        currentImage = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        currentTimeToChange += Time.deltaTime;
        currentTime += Time.deltaTime;
        if (currentTime > timeToChange / 2)
        {
            currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, currentImage.color.a - Time.deltaTime * speed);

        }
        else
        {
            currentImage.color = new Color(currentImage.color.r, currentImage.color.g, currentImage.color.b, currentImage.color.a + Time.deltaTime * speed);
        }
    }
}
