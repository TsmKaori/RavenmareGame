using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject coll = collision.gameObject;
        if (coll.tag == "Enemy")
        {
            Enemy enemyScript = coll.GetComponent<Enemy>();
            enemyScript.takeDamage(10f);
        }

        Destroy(gameObject);
    }
}
