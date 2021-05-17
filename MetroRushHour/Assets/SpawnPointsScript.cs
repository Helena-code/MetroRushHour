using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPointsScript : MonoBehaviour
{
    public GameObject greenPrefab;
    public GameObject redPrefab;
    public GameObject yellowPrefab;

    public int counterRedPrefab;
    public int counterGreenPrefab;
    public int counterYellowPrefab;

    public int chanseRedPrefab;
    public int chanseGreenPrefab;
    public int chanseYellowPrefab;

    public int randomObjects;

    [SerializeField]
    public struct SpawnPositions
    {
        public GameObject spawnPosition;
        public bool canSpawn;
    }
    [SerializeField]
    public SpawnPositions[] spawnPoints;

    private void Start()
    {
        GameObject []tmp = GameObject.FindGameObjectsWithTag("Spawn");
        spawnPoints = new SpawnPositions[tmp.Length];
        Debug.Log("Spawn points" + spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i].spawnPosition = tmp[i];
            spawnPoints[i].canSpawn = true;
        }
        SpawnPrefabs();
    }
    void SpawnPrefabs()
    {
        InstObj(counterGreenPrefab,greenPrefab);
        InstObj(counterRedPrefab, redPrefab);
        InstObj(counterYellowPrefab, yellowPrefab);

    }
    void InstObj(int count, GameObject tmp)
    {
        for (int i = 0; i < count; i++)
        {
            int random = Random.Range(0,spawnPoints.Length-1);
            while(spawnPoints[random].canSpawn != true)
            {
                random = Random.Range(0, spawnPoints.Length - 1); 
            }
            Instantiate(tmp, SearchFreeRandom().transform.position, Quaternion.identity);
        }
    }
    void InstObjWithChance(int count)
    {
        for (int i = 0; i < randomObjects; i++)
        {
            int randomNum = Random.Range(0, 100);

            if (randomNum >=chanseGreenPrefab)
            {
                Instantiate(greenPrefab, SearchFreeRandom().transform.position, Quaternion.identity);
            }
            if (randomNum > chanseGreenPrefab && randomNum <=chanseYellowPrefab )
            {
                Instantiate(yellowPrefab, SearchFreeRandom().transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(redPrefab, SearchFreeRandom().transform.position, Quaternion.identity);
            }
        }
        
    }
    GameObject SearchFreeRandom()
    {
        int random = Random.Range(0, spawnPoints.Length - 1);
        while (spawnPoints[random].canSpawn != true)
        {
            random = Random.Range(0, spawnPoints.Length - 1);
        }
        spawnPoints[random].canSpawn = false;
        return spawnPoints[random].spawnPosition;
    }


}
