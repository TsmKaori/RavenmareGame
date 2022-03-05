using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float chaseRadius = 10f;
    private bool isChasing = false;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttack;
    private Vector2 inputVector;

    public GameObject mask;
    public GameObject player;

    // enemy health
    public float currentHealth = 100;
    private float maxHealth = 100;

    void Start()
    {
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        isChasing = distanceToPlayer <= chaseRadius;
        float width = currentHealth / maxHealth;
        mask.transform.localScale = new Vector3(width, 1.0f, 1.0f);
        float xOffset = -(1.0f - (currentHealth / maxHealth)) / 2;
        mask.transform.localPosition = new Vector3(xOffset, mask.transform.localPosition.y, mask.transform.localPosition.z);
    }

    void FixedUpdate()
    {

    }
}
