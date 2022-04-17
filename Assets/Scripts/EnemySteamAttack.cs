using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySteamAttack : MonoBehaviour
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
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)  //AOE hit 
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            player.takeDamage(5);
            //Destroy(gameObject);
        }
    }
}
