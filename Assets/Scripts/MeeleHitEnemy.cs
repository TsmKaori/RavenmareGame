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
        if(col != null) {
            GameObject gameObject = col.gameObject;
            if(gameObject.tag == "Enemy") {
                Enemy enemyScript = gameObject.GetComponent<Enemy>();
                enemyScript.takeDamage(40f);
            }else if(gameObject.tag == "FirstLevelBoss")
            {
                FirstLevelBoss enemyScript = gameObject.GetComponent<FirstLevelBoss>();
                enemyScript.takeDamageNoKnockback(40f);
            }else if (gameObject.tag == "Bat")
            {
                BatEnemy enemyScript = gameObject.GetComponent<BatEnemy>();
                enemyScript.takeDamage(40f);
            }
            else if (gameObject.tag == "SteamBots")
            {
                SteambotEnemy enemyScript = gameObject.GetComponent<SteambotEnemy>();
                enemyScript.takeDamage(40f);
            }
        }
    }
}
