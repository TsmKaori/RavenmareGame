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
    public GameObject rapidFireProjPrefab;
    //public GameObject freezePrefab;
    [SerializeField]
    private Animator playerAnimator;

    public float bulletForce = 20f;

    public bool IsAvailable = true;
    public float CooldownDuration = 10.0f;

    public string facing = "down";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetFloat("lastMoveX") < -0.1) //left facing
        {
            facing = "left";
        }
        else if (playerAnimator.GetFloat("lastMoveX") > 0.1) //right facing
        {
            facing = "right";
        }
        else if (playerAnimator.GetFloat("lastMoveY") > 0.1)  //Up facing
        {
            facing = "up";
        }
        else //down facing
        {
            facing = "down";
        }
    }

    public void shoot()
    {
        explosionAbility();
    }

    public void rapidFire()
    {
        StartCoroutine(CreateRapidFireBullets());
    }

    IEnumerator CreateRapidFireBullets()
    {
        for (int i = 0;i < 30 ;i++)
        {
            GameObject rapidFireAmmo;

            if (facing.Equals("up"))
            {
                rapidFireAmmo = Instantiate(rapidFireProjPrefab, upFirePoint.position, upFirePoint.rotation);
                Rigidbody2D rb = rapidFireAmmo.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.up * bulletForce, ForceMode2D.Impulse);
            }
            else if (facing.Equals("down"))
            {
                rapidFireAmmo = Instantiate(rapidFireProjPrefab, downFirePoint.position, downFirePoint.rotation);
                Rigidbody2D rb = rapidFireAmmo.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.down * bulletForce, ForceMode2D.Impulse);
            }
            else if (facing.Equals("right"))
            {
                rapidFireAmmo = Instantiate(rapidFireProjPrefab, rightFirePoint.position, rightFirePoint.rotation);
                Rigidbody2D rb = rapidFireAmmo.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.right * bulletForce, ForceMode2D.Impulse);
            }
            else
            {
                rapidFireAmmo = Instantiate(rapidFireProjPrefab, leftFirePoint.position, leftFirePoint.rotation);
                Rigidbody2D rb = rapidFireAmmo.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.left * bulletForce, ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    void explosionAbility()
    {
        GameObject explosionProjectile;

        if (playerAnimator.GetFloat("lastMoveX") < -0.1) //left facing
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
