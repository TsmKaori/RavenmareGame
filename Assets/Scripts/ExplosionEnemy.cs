using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : MonoBehaviour
{
    public GameObject target;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillOnAnimationEnd());
        target = GameObject.Find("Player");
        player = target.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collide)  //AOE hit 
    {
        if (collide.gameObject.name.Equals("Hero"))
        {
            player.takeDamage(15);
        }
    }
}
