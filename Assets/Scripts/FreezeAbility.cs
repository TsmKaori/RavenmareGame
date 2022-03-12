using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAbility : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(KillOnAnimationEnd());
    }

    void OnTriggerEnter2D(Collider2D collision)  //AOE hit 
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Enemy")
        {
            Enemy enemyScript = gameObject.GetComponent<Enemy>();
            enemyScript.freezeAbility();
        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
