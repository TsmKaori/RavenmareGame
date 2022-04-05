using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private bool canAnimate = false;
    private bool currentlyCountdown;
    private float nextSpawnT;

    public AbilitySystem abilitySystem;
    public Animator animator;

    public TMP_Text waveCompleteText;
    public TMP_Text countdownBuffer;
    public float timeRemaining = 32;


    public 
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
        if(totEnemies.Length == 0 && canAnimate && currWaveNum+1 != waves.Length)
        {
            animator.SetTrigger("WaveComplete");
            canAnimate = false;
            currentlyCountdown = true;
            //spawnNext();
        }

        if (currentlyCountdown)
        {
            timeRemaining -= Time.deltaTime;
            int seconds = (int)timeRemaining;
            //Debug.Log(seconds);
            countdownBuffer.text = seconds.ToString();
            if (timeRemaining <= 0)
            {
                currentlyCountdown = false;
                timeRemaining = 32;
                animator.SetTrigger("BufferComplete");
                //spawnNext();
            }
        }
    }

    void spawnNext()
    {
        currWaveNum++;
        if (currWaveNum == 1)        //Add ability or whatever else need to be happen after whatever wave here
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.inferno);
        }
        else if (currWaveNum == 2)
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.ringOfFire);
        }
        else if (currWaveNum == 3)
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.grappling);
        }
        else if (currWaveNum == 4)
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.rapidFire);
        }
        else if (currWaveNum == 5)
        {

        }
        //Add wave interval here. This area can buffer until the next call
        canSpawn = true;
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
                canAnimate = true;
            }
        }
    }
}
