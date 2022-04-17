using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 10f;
    Rigidbody2D rb;

    Vector2 moveDirection;
    public GameObject target;
    public GameObject targetParent;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //target = GameObject.FindObjectOfType<Player>();
        target = GameObject.Find("Hero");
        targetParent = GameObject.Find("Player");
        player = targetParent.GetComponent<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        //player.takeDamage(10);

        if (collide.gameObject.name.Equals("Hero"))
        {
            player.takeDamage(10);
            Destroy(gameObject);
        }
    }
}
