using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRigidbody;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private float speed;
    [SerializeField]
    public Image healthBar;
    [SerializeField]
    public Image heatBar;


    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttack;
    private bool isCooling = false;
    private Vector2 inputVector;

    // player health
    private float currentHealth = 100;
    private float maxHealth = 100;

    // player heat
    private float currentHeat = 0;
    private int maxHeat = 100;

    void Start()
    {
    }

    void Update()
    {
        // update UI
        healthBar.fillAmount = currentHealth / maxHealth;
        heatBar.fillAmount = currentHeat / maxHeat;

        // update health

        // update heat
        currentHeat = Math.Max(currentHeat - 10.0f * Time.deltaTime, 0);
        if (currentHeat > maxHeat)
        {
            // disable weapon
            isCooling = true;
        }
        if(isCooling && currentHeat <= 0f) {
            isCooling = false;
        }

        // handle input
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        playerAnimator.SetFloat("moveX", inputVector.x);
        playerAnimator.SetFloat("moveY", inputVector.y);
        playerAnimator.SetFloat("velocity", inputVector.magnitude);

        if (isAttack)
        {
            playerRigidbody.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                playerAnimator.SetBool("isAttacking", false);
                isAttack = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !isCooling)
        {
            attackCounter = attackTime;
            playerAnimator.SetBool("isAttacking", true);
            isAttack = true;
            currentHeat += 10;
        }
    }

    void FixedUpdate()
    {
        playerRigidbody.velocity = inputVector * speed * Time.fixedDeltaTime;

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||  Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            playerAnimator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnimator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Enemy")                  //If get hits by basic enemy
        {
            takeDamage(40f);
        }
    }

    public void takeDamage(float damage) {
        currentHealth = Math.Max(0f, currentHealth - damage);
    }
}
