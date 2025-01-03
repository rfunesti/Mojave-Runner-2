using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    // set up for Object Pooling
    public GameObject[] obstacleInstances; // array that will contain object instances
    public int numberOfInstances = 10;
    public int instanceIndex = 0;

    public float timeToSpawnMin = 1f;
    public float timeToSpawnMax = 5f;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        obstacleInstances = new GameObject[numberOfInstances];

        for (int i = 0; i < numberOfInstances; i++)
        {
            obstacleInstances[i] = Instantiate(obstaclePrefab);
            obstacleInstances[i].transform.position = transform.position;
            obstacleInstances[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        
        if (spawnTime < 0.0f)
        {
            SpawnObstacle();
            spawnTime = Random.Range(timeToSpawnMin, timeToSpawnMax);
        }

    }

    void SpawnObstacle()
    {
        obstacleInstances[instanceIndex].SetActive(true);        
        obstacleInstances[instanceIndex].transform.position = transform.position;
        instanceIndex++;
        if (instanceIndex == numberOfInstances) instanceIndex = 0;

    }
}
