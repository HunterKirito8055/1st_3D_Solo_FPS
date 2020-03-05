using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objectSpawn;
    public int numberOfEnemies;
    public float spawnRadius =5f;

    private Vector3 spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        for(int i=0;i<numberOfEnemies;i++)
        {
            spawnPoints = transform.position + Random.insideUnitSphere * spawnRadius;

            Instantiate(objectSpawn, spawnPoints, Quaternion.identity);
        }
    }
}
