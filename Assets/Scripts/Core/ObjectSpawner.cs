using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour 
{
    [SerializeField] private List<GameObject>   spawnablePrefabs;
    [SerializeField] private float              spawnRate;
    [SerializeField] private bool               spawnOnStart;
    [SerializeField] private float              spawnDelay;

    private bool    isSpawning;
    private float   spawnTimer;
    private float   spawnDelayTimer;

    public void StartSpawning()
    {
        isSpawning = true;
        spawnDelayTimer = spawnDelay;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void Start()
    {
        if(spawnOnStart)
        {
            StartSpawning();
        }
    }

    private void Update()
    {
        if (isSpawning)
        {
            if (spawnDelayTimer >= spawnDelay)
            {
                if (spawnTimer >= spawnRate)
                {
                    Spawn();
                    spawnTimer = 0;
                }
                else
                {
                    spawnTimer += Time.deltaTime;
                }
            }
            else
            {
                spawnDelayTimer += Time.deltaTime;
            }
        }
    }

    private void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnablePrefabs.GetRandomObject(), transform.GetRandomPointInTransform(), Quaternion.identity) as GameObject;
        newSpawnedObject.transform.SetParent(transform);
    }

}
