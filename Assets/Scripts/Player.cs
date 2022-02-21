using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    //private Vector3 move;

    private Rigidbody2D rb;
    private Animator playerAnimation;

    [SerializeField]
    private float speed;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttack;

    // player health
    private int currentHealth = 100;
    private int maxHealth = 100;
    public Image healthBar;

    // player heat
    private int currentHeat = 0;
    private int maxHeat = 100;
    public Image heatBar;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // update UI
        healthBar.fillAmount = currentHealth / maxHealth;
        heatBar.fillAmount = currentHeat / maxHeat;

        // update health

        // update heat
        currentHeat = Math.Max(currentHeat - 2, 0);
        if(currentHeat > maxHeat) {
            // disable weapon
        }

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        Debug.Log(rb.velocity);
        playerAnimation.SetFloat("moveX", rb.velocity.x);
        playerAnimation.SetFloat("moveY", rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1){
            playerAnimation.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            playerAnimation.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                playerAnimation.SetBool("isAttacking", false);
                isAttack = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackCounter = attackTime;
            playerAnimation.SetBool("isAttacking", true);
            isAttack = true;
        }
    }

    
    void FixedUpdate()
    {

    }
}
