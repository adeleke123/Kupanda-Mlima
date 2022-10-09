using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] rockPrefabs;
    public GameObject powerUpPrefab;
    public GameObject thornPrefab;

    private float zSpawn = 5.0f;

    private float zThornSpawn = 4f;
    private float ySpawn = 50.0f;
    private float xSpawnRange = 42.0f;


    private float startDelay = 2.0f;
    private float thornSpawnRate = 5.0f;
    private float powerUpSpawnRate = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomRock", startDelay, Random.Range(3,7));
        InvokeRepeating("SpawnThorns", startDelay, thornSpawnRate);
        InvokeRepeating("SpawnPowerUps", startDelay, powerUpSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnThorns()
    {
        float spawnPosX = Random.Range(xSpawnRange, -xSpawnRange);
        float spawnPosY = Random.Range(20, 45);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, -zThornSpawn);


        Instantiate(thornPrefab, spawnPos, thornPrefab.transform.rotation);
    }

    void SpawnPowerUps()
    {
        float spawnPosX = Random.Range(xSpawnRange, -xSpawnRange);
        float spawnPosY = Random.Range(20, 45);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, -zThornSpawn);



        Instantiate(powerUpPrefab, spawnPos, powerUpPrefab.transform.rotation);
    }

    void SpawnRandomRock()
    {
        int rockIndex = Random.Range(0, rockPrefabs.Length);
        float randomPosX = Random.Range(xSpawnRange, -xSpawnRange);

        Vector3 randomPos = new Vector3(randomPosX, ySpawn, -zSpawn);

        Instantiate(rockPrefabs[rockIndex], randomPos, rockPrefabs[rockIndex].transform.rotation);
    }
}
