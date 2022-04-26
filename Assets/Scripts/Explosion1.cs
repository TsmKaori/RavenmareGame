using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)  //AOE hit 
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Enemy")
        {
            Enemy enemyScript = gameObject.GetComponent<Enemy>();
            enemyScript.takeDamage(80f);
        }
        else if (gameObject.tag == "FirstLevelBoss")
        {
            FirstLevelBoss enemyScript = gameObject.GetComponent<FirstLevelBoss>();
            enemyScript.takeDamageNoKnockback(80f);
        }
        else if (gameObject.tag == "Bat")
        {
            BatEnemy enemyScript = gameObject.GetComponent<BatEnemy>();
            enemyScript.takeDamageNoKnockback(80f);
        }
        else if (gameObject.tag == "SteamBots")
        {
            SteambotEnemy enemyScript = gameObject.GetComponent<SteambotEnemy>();
            enemyScript.takeDamageNoKnockback(80f);
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
    }
    */
}
