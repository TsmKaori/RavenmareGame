using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FirstLevelBoss : MonoBehaviour
{
    [SerializeField]
    private float attackRadius = 5f;
    [SerializeField]
    private int attackDamage = 2;
    [SerializeField]
    private float currentHealth = 3000;
    [SerializeField]
    private bool showAttackRadius = false;
    [SerializeField]
    private Animator basicEnemyAnimator;

    // enemy private state
    private bool isChasing = false;
    private bool isAttacking = false;
    private bool isDefense = false;
    private bool isRangeAttack = false;
    private bool isMeeloAttack = false;

    private float timeSinceAttack = 0f;
    private float attackCooldown = 1f;
    private bool isKnockedBacked = false;
    private float timeSinceKnockback = 0f;
    private float knockbackCooldown = .1f;
    private float knockbackSpeed = 100f;
    private float maxHealth = 3000;

    // enemy gameobjects
    [SerializeField]
    private GameObject mask;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private GameObject attackRadiusVisual;

    // player gameobjects
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Player playerScript;

    public GameObject shield;
    public Transform[] spawnPoints;

    public GameObject bats;
    public GameObject basicBulletPrefab;
    public GameObject steamAttackPrefab;
    public GameObject targetCirclePrefab;
    public GameObject explosionPrefab;
    public GameObject hero;

    [SerializeField] float _interval = 2f;
    float timeD;

    public bool firstDef = false;
    public bool secondDef = false;
    public bool thirdDef = false;
    // Start is called before the first frame update
    void Start()
    {
        timeD = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0f)
        {
            die();
        }

        if (currentHealth < 2300 && !firstDef && !isDefense)
        { //go to defense mode
            firstDef = true;
            isDefense = true;
            basicEnemyAnimator.SetBool("isDefense", true);
            shield.SetActive(true);
            defenseMode();
        }else if (currentHealth < 1500 && !secondDef && !isDefense)
        {
            secondDef = true;
            isDefense = true;
            basicEnemyAnimator.SetBool("isDefense", true);
            shield.SetActive(true);
            defenseMode();
        }else if (currentHealth < 800 && !thirdDef && !isDefense)
        {
            thirdDef = true;
            isDefense = true;
            basicEnemyAnimator.SetBool("isDefense", true);
            shield.SetActive(true);
            defenseMode();
        }

        timeD += Time.deltaTime;
        while (timeD >= _interval)
        {
            makeDecision();
            timeD -= _interval;
        }

        // move mask to make the enemy health bar match currentHealth
        float width = currentHealth / maxHealth;
        mask.transform.localScale = new Vector3(width, 1.0f, 1.0f);
        float xOffset = -(1.0f - (currentHealth / maxHealth)) / 2;
        mask.transform.localPosition = new Vector3(xOffset, mask.transform.localPosition.y, mask.transform.localPosition.z);
    }

    public void takeDamageNoKnockback(float damage)
    {
        if (!isDefense)
        {
            currentHealth = Math.Max(0f, currentHealth - damage);
        }
    }

    void die()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        basicEnemyAnimator.SetTrigger("death");
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(2f);
        System.Random rnd = new System.Random();
        int gold = rnd.Next(5, 10);
        playerScript.addGold(gold);
        Destroy(gameObject);
    }

    void defenseMode()
    {
        StartCoroutine(defense());
        InvokeRepeating("spawnEnemies", 1.0f, 1f);
    }

    IEnumerator defense()
    {
        yield return new WaitForSeconds(10f);
        isDefense = false;
        basicEnemyAnimator.SetBool("isDefense", false);
        shield.SetActive(false);
        CancelInvoke();
    }

    IEnumerator range()
    {
        yield return new WaitForSeconds(1f);
        basicEnemyAnimator.SetBool("isRangeAttack", false);
        isRangeAttack = false;
    }

    IEnumerator steam()
    {
        yield return new WaitForSeconds(1f);
        basicEnemyAnimator.SetBool("abilityUsed", false);
    }

    IEnumerator explosion(GameObject circle, Vector3 pos, Quaternion rot)
    {
        yield return new WaitForSeconds(3f);
        Destroy(circle);
        GameObject explosion = Instantiate(explosionPrefab, pos, rot);
    }


    void makeDecision()
    {
        int random = UnityEngine.Random.Range(0, 100);
        if(random < 70 && !isDefense) //shoot
        {
            basicEnemyAnimator.SetBool("isRangeAttack", true);
            isRangeAttack = true;
            GameObject basicbullet = Instantiate(basicBulletPrefab, transform.position, transform.rotation);
            StartCoroutine(range());
        }
        else if(random > 70 && random < 80 && !isDefense) //Use ability 1
        {
            GameObject basicbullet = Instantiate(steamAttackPrefab, transform.position, transform.rotation);
            basicEnemyAnimator.SetBool("abilityUsed",true);
            StartCoroutine(steam());
        }
        else if(random > 80 && !isDefense)
        {
            GameObject targetCircle = Instantiate(targetCirclePrefab, hero.transform.position, hero.transform.rotation);
            StartCoroutine(explosion(targetCircle,hero.transform.position, hero.transform.rotation));
        }
    }

    void spawnEnemies()
    {
        int random = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform ranPoint = spawnPoints[random];
        Instantiate(bats, ranPoint.position, Quaternion.identity);
    }

    
}
