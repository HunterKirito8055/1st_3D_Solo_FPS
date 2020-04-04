using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawners;

    BoxCollider trigger;

    private void Start()
    {
        trigger=GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            SpawnEnemies();
            trigger.enabled = false;
        }
    }

    void SpawnEnemies()
    {
        foreach(var sp in spawners)
        {
            Instantiate(enemy, sp.position, Quaternion.identity);
        }
    }
}
