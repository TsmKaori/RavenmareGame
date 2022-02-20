using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
