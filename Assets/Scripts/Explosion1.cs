using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)  //AOE hit 
    {
        Debug.Log("hit");
        Destroy(collision.gameObject); //Detroy object for now. Implement health deduction here.
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
    }
    */
}
