using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public float timeRemaining = 17;

    [SerializeField] LayerMask gappleMask;
    [SerializeField] Transform playerTransform;
    public bool[] activeSpawnPoint;

    [SerializeField] GameObject shopDialog;

    public DialogueTrigger dialogueSys;
    public DialogueManager dialogue;
    public bool firstWaveDialogue = true;

    public bool bossWave = false;
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Vector2 direction = spawnPoints[i].position - playerTransform.position;
            float dist = Vector2.Distance(spawnPoints[i].position, playerTransform.position);
            RaycastHit2D rayc = Physics2D.Raycast(playerTransform.position, direction, dist, ~gappleMask);

            if (rayc.collider)
            {
                activeSpawnPoint[i] = false;
            }
            else
            {
                activeSpawnPoint[i] = true;
            }
        }

        currWave = waves[currWaveNum];
        if(currWaveNum == 0 && firstWaveDialogue)  //first dialogue before first wave
        {
            triggerNextWaveActions();
            firstWaveDialogue = false;
        }
        if (!dialogue.dialogueActive)  //spawn next if dialogue is not active
        {
            SpawnWave();
        }

        //GameObject[] totEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] totBoss = GameObject.FindGameObjectsWithTag("FirstLevelBoss");
        GameObject[] totBats = GameObject.FindGameObjectsWithTag("Bat");
        GameObject[] totSteamBot = GameObject.FindGameObjectsWithTag("SteamBots");
        GameObject[] totRegEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        int totEnemies = totBoss.Length + totBats.Length + totSteamBot.Length + totRegEnemy.Length;

        if (totEnemies == 0 && canAnimate && currWaveNum+1 != waves.Length)
        {
            animator.SetTrigger("WaveComplete");
            canAnimate = false;
            currentlyCountdown = true;
            shopDialog.SetActive(true);
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
                timeRemaining = 17;
                animator.SetTrigger("BufferComplete");
                shopDialog.SetActive(false);
                //spawnNext();
            }
        }

        if(bossWave && !boss) //killed boss on boss wave
        {
            SceneManager.LoadScene("PostLevelOneCutScene");
        }
    }

    void spawnNext()
    {
        currWaveNum++;
        triggerNextWaveActions();
        canSpawn = true;
    }

    void triggerNextWaveActions()
    {
        if (currWaveNum == 0)
        {
            dialogueSys.triggerFirstWaveDialogue();
        }
        else if (currWaveNum == 1)        //Add ability or whatever else need to be happen after whatever wave here
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.inferno);
            dialogueSys.triggerSecondWaveDialogue();
        }
        else if (currWaveNum == 2)
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.ringOfFire);
            dialogueSys.triggerThirdWaveDialogue();
        }
        else if (currWaveNum == 3)
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.grappling);
            dialogueSys.triggerFourthWaveDialogue();
        }
        else if (currWaveNum == 4)
        {
            abilitySystem.unlockAbilties(AbilitySystem.SkillType.rapidFire);
            dialogueSys.triggerFifthWaveDialogue();
        }
        else if (currWaveNum == 5)
        {
            dialogueSys.triggerBossWaveDialogue();
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnT < Time.time)
        {
            GameObject ranEnemy = currWave.typeOfEnemies[Random.Range(0, currWave.typeOfEnemies.Length)];
            int random = Random.Range(0, spawnPoints.Length);
            int breakpoint = 0;
            Transform ranPoint;
            while (!activeSpawnPoint[random])
            {
                random = Random.Range(0, spawnPoints.Length);
                //Debug.Log(activeSpawnPoint[random] + "  here");
                breakpoint++;
                if(breakpoint > 10000)
                {
                    break;
                }
            }
            ranPoint = spawnPoints[random];
            //Debug.Log(activeSpawnPoint[random]);
            if(currWave.nameOfWave.Equals("Boss"))    //Boss wave
            {
                Vector3 newPos = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
                boss = Instantiate(ranEnemy, newPos, Quaternion.identity);
                bossWave = true;
            }
            else   //regular WAVE
            {
                if (breakpoint <= 10000)
                {
                    Instantiate(ranEnemy, ranPoint.position, Quaternion.identity);
                }
                else
                {
                    //Debug.Log("really random");
                    Vector3 newPos = new Vector3(playerTransform.position.x + 1, playerTransform.position.y, playerTransform.position.z);
                    Instantiate(ranEnemy, newPos, Quaternion.identity);
                }
            }

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
