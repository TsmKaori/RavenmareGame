using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjectile : MonoBehaviour
{
    public GameObject explosion;

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
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);  //Creates explosion then destory it
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

}
