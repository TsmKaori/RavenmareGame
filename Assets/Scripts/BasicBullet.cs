using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
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
            enemyScript.takeDamageNoKnockback(70f);
        }
        else if (coll.tag == "FirstLevelBoss")
        {
            FirstLevelBoss enemyScript = coll.GetComponent<FirstLevelBoss>();
            enemyScript.takeDamageNoKnockback(70f);
        }
        else if (coll.tag == "Bat")
        {
            BatEnemy enemyScript = gameObject.GetComponent<BatEnemy>();
            enemyScript.takeDamageNoKnockback(70f);
        }
        else if (coll.tag == "SteamBots")
        {
            SteambotEnemy enemyScript = gameObject.GetComponent<SteambotEnemy>();
            enemyScript.takeDamageNoKnockback(70f);
        }

        Destroy(gameObject);
    }
}
