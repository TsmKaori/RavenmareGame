using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float thrust;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("wee");
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            StartCoroutine(KnockCoroutine(enemy));
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        try {
            Vector2 forceDirection = enemy.transform.position - transform.position;
            Vector2 force = forceDirection.normalized * thrust;
            enemy.velocity = force;
        } catch(MissingReferenceException e) {}

        yield return new WaitForSeconds(.3f);

        try {
            enemy.velocity = new Vector2();
        } catch(MissingReferenceException e) {}
    }
}
