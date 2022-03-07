using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleHitEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject gameObject = col.gameObject;
        if(gameObject.tag == "Enemy") {
            Enemy enemyScript = gameObject.GetComponent<Enemy>();
            enemyScript.takeDamage(40f);
        }
    }
}
