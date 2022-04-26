using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BatEnemy : MonoBehaviour
{
    // enemy public state
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float chaseRadius = 10f;
    [SerializeField]
    private float attackRadius = 1f;
    [SerializeField]
    private int attackDamage = 2;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    private bool showAttackRadius = false;
    [SerializeField]
    private Animator basicEnemyAnimator;

    // enemy private state
    private bool isChasing = false;
    private bool isAttacking = false;
    private float timeSinceAttack = 0f;
    private float attackCooldown = 1f;
    private float maxHealth = 100;
    private bool isKnockedBacked = false;
    private float timeSinceKnockback = 0f;
    private float knockbackCooldown = .1f;
    private float knockbackSpeed = 100f;
    private bool isDead = false;

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

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        attackRadiusVisual.SetActive(showAttackRadius);
        if (showAttackRadius)
        {
            attackRadiusVisual.transform.localScale = new Vector3(attackRadius * 2.0f, attackRadius * 2.0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0f)
        {
            die();
        }
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // attack if within attack radius
        // attack if within attack radius
        isAttacking = distanceToPlayer <= attackRadius;
        if (isAttacking && !isDead)
        {
            if (timeSinceAttack >= attackCooldown)
            {
                playerScript.takeDamage(attackDamage);
                timeSinceAttack = 0f;
            }
            else
            {
                timeSinceAttack += Time.deltaTime;
            }
        }

        // chase if within radius
        isChasing = distanceToPlayer <= chaseRadius;

        // move mask to make the enemy health bar match currentHealth
        float width = currentHealth / maxHealth;
        mask.transform.localScale = new Vector3(width, 1.0f, 1.0f);
        float xOffset = -(1.0f - (currentHealth / maxHealth)) / 2;
        mask.transform.localPosition = new Vector3(xOffset, mask.transform.localPosition.y, mask.transform.localPosition.z);
    }

    void FixedUpdate()
    {
        if (isChasing)
        {
            //basicEnemyAnimator.SetBool("isMoving", true);
            rigidbody.velocity = (player.transform.position - transform.position) * speed * Time.fixedDeltaTime;
        }
        else
        {
            //basicEnemyAnimator.SetBool("isMoving", false);
        }
        if (isKnockedBacked)
        {
            if (timeSinceKnockback >= knockbackCooldown)
            {
                isKnockedBacked = false;
            }
            else
            {
                timeSinceKnockback += Time.fixedDeltaTime;
                rigidbody.velocity = (transform.position - player.transform.position) * knockbackSpeed * Time.fixedDeltaTime;
            }
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth = Math.Max(0f, currentHealth - damage);
        isKnockedBacked = true;
        timeSinceKnockback = 0f;
    }

    public void takeDamageNoKnockback(float damage)
    {
        currentHealth = Math.Max(0f, currentHealth - damage);
    }


    public void freezeAbility()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(freeze(6));
    }

    void die()
    {
        isDead = true;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        basicEnemyAnimator.SetTrigger("death");
        StartCoroutine(death());
    }

    IEnumerator freeze(int secs)
    {
        yield return new WaitForSeconds(secs);
        rigidbody.constraints = RigidbodyConstraints2D.None;
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(1f);
        System.Random rnd = new System.Random();
        int gold = rnd.Next(1, 2);
        playerScript.addGold(gold);
        Destroy(gameObject);
    }
}
