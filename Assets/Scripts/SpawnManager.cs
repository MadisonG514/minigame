using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 7;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private float spawnPosY = 7;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void SpawnRandomObject()
    {
         int objectIndex = Random.Range(0, objectPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), transform.position.y, transform.position.z);
            
            Instantiate(objectPrefabs[objectIndex], spawnPos, transform.rotation);
    }
}