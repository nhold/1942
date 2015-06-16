using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour 
{
    [SerializeField] private List<GameObject> spawnPrefabData;
    [SerializeField] private float spawnRate;
    [SerializeField] private bool spawnOnStart;

    private float spawnTimer;

    private bool isSpawning;
    public bool IsSpawning
    {
        get
        {
            return isSpawning;
        }
        set
        {
            isSpawning = value;
        }
    }

    void Awake()
    {
        spawnTimer = 0.0f;
    }

    void Start()
    {
        if(spawnOnStart)
        {
            IsSpawning = true;
        }
    }

    void Update()
    {
        if(IsSpawning)
        {
            spawnTimer += Time.deltaTime;
            if(spawnTimer > spawnRate)
            {
                Spawn();
                spawnTimer = 0;
            }
        }
    }

    private void Spawn()
    {
        Vector3 rndPosWithin;
        rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0.0f);
        rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
        int randomIndex = Random.Range(0, spawnPrefabData.Count);
        GameObject newSpawnedObject = Instantiate(spawnPrefabData[randomIndex], rndPosWithin, Quaternion.identity) as GameObject;

    }
}
