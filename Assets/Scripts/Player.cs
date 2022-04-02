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
    private Image statusBar;
    [SerializeField]
    private GameObject healthBar;
    private Image[] healthBars;
    [SerializeField]
    private Sprite[] statusBars;
    [SerializeField]
    private Text goldText;
    [SerializeField]
    private Text numHealthPotionsText;

    private int gold = 0;

    public int attackDamage = 40;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttack;
    private bool isCooling = false;
    private Vector2 inputVector;

    // player health
    private int currentHealth = 100;
    private int maxHealth = 100;
    private bool isDead = false;
    private int numHealthPotions = 0;

    // player heat
    private float currentHeat = 0;
    private int maxHeat = 100;

    void Start()
    {
        int numHealthBars = healthBar.transform.childCount;
        healthBars = new Image[numHealthBars];
        for(int i = 0; i < numHealthBars; i++) {
            healthBars[i] = healthBar.gameObject.transform.GetChild(i).GetComponent<Image>();
        }
    }

    void Update()
    {
        if(!isDead) {
            // update UI
            updateHealthBar();
            updateHeatBar();
            goldText.text = "Gold: " + gold;
            numHealthPotionsText.text = "Potions: " + numHealthPotions;

            // update heat
            currentHeat = Math.Max(currentHeat - 5.0f * Time.deltaTime, 0f);
            if (currentHeat >= maxHeat)
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
                currentHeat = Math.Min(100.0f, currentHeat + 10f);
            }
            if(currentHealth <= 0) {
                isDead = true;
            }
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
            takeDamage(attackDamage);
        }
    }

    void updateHealthBar() {
        int numHealthBars = healthBars.Length;
        float currentHealthPercentage = (float) currentHealth / (float) maxHealth;
        for(int i = 0; i < numHealthBars; i++) {
            float fillAmount = (currentHealthPercentage - (i * (1.0f / numHealthBars))) / (1.0f / numHealthBars);
            healthBars[i].fillAmount = fillAmount;
        }
    }

    void updateHeatBar() {
        int numHeatBulbs = statusBars.Length - 1;
        float currentHeatPercentage = currentHeat / (float) maxHeat;
        int heatBulbsLit = (int) Math.Round(currentHeatPercentage * numHeatBulbs, MidpointRounding.AwayFromZero);
        statusBar.sprite = statusBars[heatBulbsLit];
    }

    public void healDamage(int amount) {
        currentHealth = Math.Min(maxHealth, currentHealth + amount);
        updateHealthBar();
    }

    public void takeDamage(int amount) {
        currentHealth = Math.Max(0, currentHealth - amount);
        updateHealthBar();
    }

    public void addGold(int amount) {
        gold += amount;
    }

    public bool takeGold(int amount) {
        if(gold >= amount) {
            gold -= amount;
            return true;
        } else {
            return false;
        }
    }

    public void increaseMaxHealth(int amount) {
        maxHealth += amount;
    }

    public void increaseAttackDamage(int amount) {
        attackDamage += amount;
    }

    public void addHealthPotion() {
        numHealthPotions++;
    }
}
