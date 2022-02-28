using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftFirePoint;
    public Transform rightFirePoint;
    public Transform upFirePoint;
    public Transform downFirePoint; 

    public GameObject explosionProjPrefab;
    [SerializeField]
    private Animator playerAnimator;

    public float bulletForce = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            shoot();
        }
    }

    void shoot()
    {
        GameObject explosionProjectile;

        if(playerAnimator.GetFloat("lastMoveX") < -0.1) //left facing
        {
            explosionProjectile = Instantiate(explosionProjPrefab, leftFirePoint.position, leftFirePoint.rotation);
            Rigidbody2D rb = explosionProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector3.left * bulletForce, ForceMode2D.Impulse);
        }
        else if (playerAnimator.GetFloat("lastMoveX") > 0.1) //right facing
        {
            explosionProjectile = Instantiate(explosionProjPrefab, rightFirePoint.position, rightFirePoint.rotation);
            Rigidbody2D rb = explosionProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector3.right * bulletForce, ForceMode2D.Impulse);
        }
        else if (playerAnimator.GetFloat("lastMoveY") > 0.1)  //Up facing
        {
            explosionProjectile = Instantiate(explosionProjPrefab, upFirePoint.position, upFirePoint.rotation);
            Rigidbody2D rb = explosionProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector3.up * bulletForce, ForceMode2D.Impulse);
        }
        else //down facing
        {
            explosionProjectile = Instantiate(explosionProjPrefab, downFirePoint.position, downFirePoint.rotation);
            Rigidbody2D rb = explosionProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector3.down * bulletForce, ForceMode2D.Impulse);
        }

    }
}
