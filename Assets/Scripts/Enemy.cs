using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // enemy public state
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float chaseRadius = 10f;
    [SerializeField]
    private float attackRadius = 1f;
    [SerializeField]
    private float attackDamage = 2f;
    [SerializeField]
    private float currentHealth = 100;
    [SerializeField]
    private bool showAttackRadius = false;

    // enemy private state
    private bool isChasing = false;
    private bool isAttacking = false;
    private float timeSinceAttack = 0f;
    private float attackCooldown = 1f;
    private float maxHealth = 100;

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
    

    void Start()
    {
        attackRadiusVisual.SetActive(showAttackRadius);
        if(showAttackRadius) {
            attackRadiusVisual.transform.localScale = new Vector3(attackRadius * 2.0f, attackRadius * 2.0f, 0f);
        }
    }

    void Update()
    {
        if(currentHealth <= 0f) {
            Destroy(gameObject);
        }
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // attack if within attack radius
        isAttacking = distanceToPlayer <= attackRadius;
        if(isAttacking) {
            if(timeSinceAttack >= attackCooldown) {
                playerScript.takeDamage(attackDamage);
                timeSinceAttack = 0f;
            } else {
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
        if(isChasing) {
            rigidbody.velocity = (player.transform.position - transform.position) * speed * Time.fixedDeltaTime;
        }
    }

    public void takeDamage(float damage) {
        currentHealth = Math.Max(0f, currentHealth - damage);
    }

    public void freezeAbility()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(freeze(6));
    }

    IEnumerator freeze(int secs)
    {
        yield return new WaitForSeconds(secs);
        rigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
