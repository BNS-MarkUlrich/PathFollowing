using Opdrachten;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public Health player;
    public float deadPlayer;
    //public Enemy enemies;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    private void Update()
    {
        deadPlayer = player._currentHealth;
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if(deadPlayer == 0)
        {
            stopSpawning = true;
        }
        
        if (stopSpawning)
        {
            // Do something
            CancelInvoke("SpawnObject");
        }
    }
}
