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
        Debug.Log("hit");
        if (gameObject.tag == "Enemy")
        {
            Enemy enemyScript = gameObject.GetComponent<Enemy>();
            enemyScript.takeDamage(0.3f);
        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
