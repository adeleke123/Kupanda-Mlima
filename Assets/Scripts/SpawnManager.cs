using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] rockPrefabs;

    private float zSpawn = 2.0f;
    private float ySpawn = 50.0f;
    private float xSpawnRange = 42.0f;

    private float startDelay = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomRock", startDelay, Random.Range(3,7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomRock()
    {
        int rockIndex = Random.Range(0, rockPrefabs.Length);
        float randomPosX = Random.Range(xSpawnRange, -xSpawnRange);

        Vector3 randomPos = new Vector3(randomPosX, ySpawn, zSpawn);

        Instantiate(rockPrefabs[rockIndex], randomPos, rockPrefabs[rockIndex].transform.rotation);
    }
}
