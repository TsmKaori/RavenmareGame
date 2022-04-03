using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string nameOfWave;
    public int numOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}


public class WaveController : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currWave;
    private int currWaveNum;


    private bool canSpawn = true;   //This indicate if can spawn. Turn off if dont want to spawn intitally
    private float nextSpawnT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currWave = waves[currWaveNum];
        SpawnWave();

        GameObject[] totEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totEnemies.Length == 0 && !canSpawn && currWaveNum+1 != waves.Length)
        {
            //Add wave interval here. This area can buffer until the next call
            currWaveNum++;
            canSpawn = true;
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnT < Time.time)
        {
            GameObject ranEnemy = currWave.typeOfEnemies[Random.Range(0, currWave.typeOfEnemies.Length)];
            Transform ranPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            //Debug.Log(ranPoint.position);
            Instantiate(ranEnemy, ranPoint.position, Quaternion.identity);

            currWave.numOfEnemies--;
            nextSpawnT = Time.time + currWave.spawnInterval;
            if(currWave.numOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }
}
