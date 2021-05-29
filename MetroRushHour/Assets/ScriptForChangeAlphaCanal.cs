using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForChangeAlphaCanal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] images;
    public GameObject[] positions;
    public float timer;
    public int index;
    public bool GO = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index < images.Length)
        {
            StartCoroutine(startCor());
        }
    }

    IEnumerator startCor()
    {
        if (GO == true) {
            GO = false;
            yield return new WaitForSeconds(timer / 3);
            if (index < images.Length)
            {
                GameObject ter = Instantiate(images[index]);
                
                ter.gameObject.SetActive(true);
                ter.transform.SetParent(transform);
                ter.transform.position = positions[index].transform.position;
                ter.gameObject.transform.localScale = new Vector3(2, 2, 2);
                yield return new WaitForSeconds(timer / 3);
                
                
                yield return new WaitForSeconds(timer / 3);
                index++;
                ter.gameObject.SetActive(false);
                Destroy(ter);
                //Debug.Log("Destroy");
                GO = true;
            }
        }
    }
}
