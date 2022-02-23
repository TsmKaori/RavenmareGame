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
    private Vector2 inputVector;

    // player health
    private int currentHealth = 100;
    private int maxHealth = 100;

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
        Debug.Log(currentHeat);

        // update health

        // update heat
        currentHeat = Math.Max(currentHeat - 10.0f * Time.deltaTime, 0);
        if (currentHeat > maxHeat)
        {
            // disable weapon
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

        if (Input.GetKeyDown(KeyCode.Q))
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

    }
}
