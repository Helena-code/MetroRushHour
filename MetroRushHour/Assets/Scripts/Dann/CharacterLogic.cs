using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    Color characterColor;
    Color robbedColor;
    public GameObject characterSkin;
    public int spawnChance;
    public bool isDeparted = false;
    public bool isRobbed = false;
    float waitTime;
    public float totalTime = 8f;
    float transparency = 0f;
    void Awake()
    {
        // robbedColor = new Color(255f, 255f, 255f, 100f);
        //Color characterColor = characterSkin.GetComponent<MeshRenderer>().material.color;
        Color characterColor = characterSkin.GetComponent<SkinnedMeshRenderer>().material.color;
        StartCoroutine(Sample(characterColor));
    }
    private IEnumerator Sample(Color startingColor)
    {   
        while (transparency <= 1)
        {
            Transparency(startingColor, 1);
            yield return null;
        }
        while (!isRobbed && waitTime < totalTime)
        {
            yield return new WaitForSeconds(0.5f);
            waitTime += 0.5f;
        }
        // if (isRobbed)
        // {
        //     Debug.Log(characterColor.r + " " + robbedColor.r);
        //     characterColor = characterSkin.GetComponent<MeshRenderer>().material.color;
        //     characterSkin.GetComponent<MeshRenderer>().material.color = Color.Lerp(characterColor, robbedColor, Time.deltaTime / 10);
        // }
        while (transparency >= 0)
        {
            Transparency(startingColor, -1);
            yield return null;
        }
        Destroy(gameObject);
        yield return new WaitForSeconds(0.5f);
    }
    void Transparency(Color color, int modifier)
    {
        color.a = transparency;
        //characterSkin.GetComponent<MeshRenderer>().material.color = color;
        characterSkin.GetComponent<SkinnedMeshRenderer>().material.color = color;
        transparency += Time.deltaTime * modifier;
    }
    // void ToRobbedColor(Color color)
    // {

    // }
}
