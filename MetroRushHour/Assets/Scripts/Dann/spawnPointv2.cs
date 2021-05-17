using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPointv2 : MonoBehaviour
{
    float timeBeforeSpawn;

    public List<GameObject> spawnObjects = new List<GameObject>();

    Vector3 spawnPosition;

    GameObject spawningObject;
    // Start is called before the first frame update
    void Start()
    {
        // if (GameObject.FindGameObjectsWithTag("Crowd").Length <= 1)
        // {
        //     for (int i = 0; i < spawnObjects.Count; i++)
        //     {
        //         if (spawnObjects[i].gameObject.tag == "Crowd")
        //         {
        //             spawningObject = spawnObjects[i];
        //         }
        //     }
        // }
        // else
        // {
        //     foreach (GameObject so in spawnObjects)
        //     {
        //         int spawnChance = so.GetComponent<CharacterLogic>().spawnChance;
        //         if(Random.Range(0,10) > spawnChance)
        //         {
        //            spawningObject = so; 
        //         }
        //     }
        // }
        spawnPosition = new Vector3(
            transform.position.x,
            transform.Find("SpawnPoint").transform.position.y,
            transform.position.z
        );
    
        
        // timeBeforeSpawn = spawningObject.GetComponent<CharacterLogic>().totalTime;
        // Invoke("Spawner(spawningObject, spawnPosition)", Random.Range(0.2f, 0.8f));
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            // yield return new WaitForSeconds(timeBeforeSpawn + 3f);
            if (GameObject.FindGameObjectsWithTag("Crowd").Length <= 0)
            {
                for (int i = 0; i < spawnObjects.Count; i++)
                {
                    if (spawnObjects[i].gameObject.tag == "Crowd")
                    {
                        spawningObject = spawnObjects[i];
                    }
                }
            }
            else
            {
                foreach (GameObject so in spawnObjects)
                {
                    int spawnChance = so.GetComponent<CharacterLogic>().spawnChance;
                    if(spawnChance <= Random.Range(0,10))
                    {
                        spawningObject = so;
                    }
                }
            }
            timeBeforeSpawn = spawningObject.GetComponent<CharacterLogic>().totalTime;
            yield return new WaitForSeconds(timeBeforeSpawn + Random.Range(0f, 4f));
            Instantiate(spawningObject, spawnPosition, Quaternion.identity);
        }
    }
    void Spawner(GameObject obj, Transform pos)
    {
        Instantiate(obj, pos.position, Quaternion.identity);
    }
}
