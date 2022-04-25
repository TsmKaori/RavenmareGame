using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillOnAnimationEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)  //AOE hit 
    {
        GameObject gameObject = collision.gameObject;
        //Debug.Log("hit");
        if (gameObject.tag == "Enemy")
        {
            Enemy enemyScript = gameObject.GetComponent<Enemy>();
            enemyScript.takeDamageNoKnockback(0.6f);
            //Debug.Log("DOT");
        }
    }
   
    void OnTriggerEnter2D(Collider2D collision)  //AOE hit 
    {
        GameObject gameObject = collision.gameObject;
        //Debug.Log("hit");
        if (gameObject.tag == "Enemy")
        {
            Enemy enemyScript = gameObject.GetComponent<Enemy>();
            enemyScript.takeDamageNoKnockback(15f);
        }
        else if (gameObject.tag == "FirstLevelBoss")
        {
            FirstLevelBoss enemyScript = gameObject.GetComponent<FirstLevelBoss>();
            enemyScript.takeDamageNoKnockback(15f);
        }
        else if (gameObject.tag == "Bat")
        {
            BatEnemy enemyScript = gameObject.GetComponent<BatEnemy>();
            enemyScript.takeDamage(15f);
        }
        else if (gameObject.tag == "SteamBots")
        {
            SteambotEnemy enemyScript = gameObject.GetComponent<SteambotEnemy>();
            enemyScript.takeDamage(15f);
        }
    }
    
    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
