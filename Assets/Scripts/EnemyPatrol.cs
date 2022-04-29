using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyPatrol : MonoBehaviour
{

    private Animator animator;
    [SerializeField]
    private float speed = 1f;

    int direction = 0;
    float timeBetweenSwitch = 1f;
    float timeSinceSwitch = 0f;
    System.Random random = new System.Random();

    void Start()
    {
        animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceSwitch += Time.fixedDeltaTime;
        if(timeSinceSwitch >= timeBetweenSwitch) {
            timeSinceSwitch = 0;
            direction = random.Next(3) - 1;
            timeBetweenSwitch = random.Next(7) + 3;
            Debug.Log(direction);
            switch(direction) {
            case -1:
            case 1:
                animator.SetBool("isMoving", true);
                break;
            default:
                animator.SetBool("isMoving", false);
                break;
            
            }
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(direction * speed, 0, 0);
    }
}
