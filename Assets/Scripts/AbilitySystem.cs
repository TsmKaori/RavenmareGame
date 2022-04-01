using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour
{
    public enum SkillType
    {
        explodingProjectile,
        freeze,
        ringOfFire,
        inferno,
        grappling,
        rapidFire
    }

    private List<SkillType> unlockedSkills = new List<SkillType>();


    public string ability1 = "freeze";
    public string ability2 = "freeze";
    public string ability3 = "grappling";

    public int ability1Cooldown = 0;
    public int ability2Cooldown = 0;
    public int ability3Cooldown = 0;

    bool explodingProjectileIsCooldown;
    bool freezeIsCooldown;
    bool burningIsCoolDown;
    bool ringOfFireIsCooldown;
    bool grapplingIsCooldown;
    bool rapidFireIsCooldown;
    bool electricityIsCooldown;

    public float explodingProjectileCooldown = 30;
    public float freezeCooldown = 30;
    public float burningCooldown = 30;
    public float ringOfFireCooldown = 30;
    public float grapplingCooldown = 10;
    public float rapidFireCooldown = 20;
    public float electricityCooldown = 60;

    
    public Image explodingProjectilePic;
    public Image freezePic;
    public Image burningPic;
    public Image ringOfFirePic;
    public Image grapplingPic;
    public Image rapidFirePic;
    public Image electricityPic;

    public Image explodingProjectileCenterPic;
    public Image freezeCenterPic;
    public Image burningCenterPic;
    public Image ringOfFireCenterPic;
    public Image grapplingCenterPic;
    public Image rapidFireCenterPic;
    public Image electricityCenterPic;


    public GameObject freezePrefab;
    public GameObject ringOfFirePrefab;
    public GameObject burningPrefab;
    public shooting shootingScript;
    public GrappleAbility grapplingScript;

    [SerializeField]
    private GameObject player;

    public bool IsAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        ability1 = "explodingProjectile";

        explodingProjectileIsCooldown = false;
        freezeIsCooldown = false;
        burningIsCoolDown = false;
        ringOfFireIsCooldown = false;
        grapplingIsCooldown = false;
        rapidFireIsCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        UseAbility();

        if (explodingProjectileIsCooldown)
        {
            explodingProjectilePic.fillAmount += ((1 / explodingProjectileCooldown * Time.deltaTime));

            if (explodingProjectilePic.fillAmount >= 1)
            {
                explodingProjectilePic.fillAmount = 1;
                explodingProjectileIsCooldown = false;
                explodingProjectileCenterPic.enabled = true;
            }
        }
        
        if (freezeIsCooldown)
        {
            freezePic.fillAmount += ((1 / freezeCooldown * Time.deltaTime));

            if (freezePic.fillAmount >= 1)
            {
                freezePic.fillAmount = 1;
                freezeIsCooldown = false;
                freezeCenterPic.enabled = true;
            }
        }


        if (burningIsCoolDown)
        {
            burningPic.fillAmount += ((1 / burningCooldown * Time.deltaTime));

            if (burningPic.fillAmount >= 1)
            {
                burningPic.fillAmount = 1;
                burningIsCoolDown = false;
                burningCenterPic.enabled = true;
            }
        }


        if (ringOfFireIsCooldown)
        {
           ringOfFirePic.fillAmount += ((1 / ringOfFireCooldown * Time.deltaTime));

            if (ringOfFirePic.fillAmount >= 1)
            {
                ringOfFirePic.fillAmount = 1;
                ringOfFireIsCooldown = false;
                ringOfFireCenterPic.enabled = true;
            }
        }


        if (grapplingIsCooldown)
        {
            grapplingPic.fillAmount += ((1 / grapplingCooldown * Time.deltaTime));

            if (grapplingPic.fillAmount >= 1)
            {
                grapplingPic.fillAmount = 1;
                grapplingIsCooldown = false;
                grapplingCenterPic.enabled = true;
            }
        }


        if (rapidFireIsCooldown)
        {
            rapidFirePic.fillAmount += ((1 / rapidFireCooldown * Time.deltaTime));

            if (rapidFirePic.fillAmount >= 1)
            {
                rapidFirePic.fillAmount = 1;
                rapidFireIsCooldown = false;
                rapidFireCenterPic.enabled = true;
            }
        }
        
    }

    void UseAbility()
    {
        if (IsAvailable == false)
        {
            return;
        }

        //Set up which one
        if (Input.GetKeyDown(KeyCode.E))
        {
            useAbility1();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            useAbility2();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            useAbility3();
        }
    }

    public void useAbility1()
    {
        if (ability1 == "explodingProjectile")
        {
            shootingScript.shoot();
            //StartCoroutine(StartCooldown(6));
        }
        else if (ability1 == "freeze")
        {
            GameObject freezeEffect = Instantiate(freezePrefab, player.transform.position, player.transform.rotation);
            //StartCoroutine(StartCooldown(6));
        }
        else if (ability1 == "burning")
        {
            GameObject burningEffect = Instantiate(burningPrefab, player.transform.position, player.transform.rotation);
            //StartCoroutine(StartCooldown(6));
        }
        else if (ability1 == "ringOfFire")
        {
            GameObject ringOfFireEffect = Instantiate(ringOfFirePrefab, player.transform.position, player.transform.rotation);
            //StartCoroutine(StartCooldown(6));
        }
        else if (ability1 == "grappling")
        {
            grapplingScript.BeginGrapple();
            //StartCoroutine(StartCooldown(2));
        }
        else if (ability1 == "rapidFire")
        {
            shootingScript.rapidFire();
            //StartCoroutine(StartCooldown(4));
        }
    }

    public void useAbility2()
    {

    }

    public void useAbility3()
    {

    }

    public void explodingProjectile()
    {
        
        if(explodingProjectileIsCooldown == false)
        {
            explodingProjectileIsCooldown = true;
            explodingProjectileCenterPic.enabled = false;

            explodingProjectilePic.fillAmount = 0;
            shootingScript.shoot();
        }
    }

    public void freeze()
    {
        
        if (freezeIsCooldown == false)
        {
            freezeIsCooldown = true;
            freezeCenterPic.enabled = false;

            freezePic.fillAmount = 0;
            GameObject freezeEffect = Instantiate(freezePrefab, player.transform.position, player.transform.rotation);
        }
        
    }

    public void ringOfFire()
    {
        
        if (ringOfFireIsCooldown == false)
        {
            ringOfFireIsCooldown = true;
            ringOfFireCenterPic.enabled = false;

            ringOfFirePic.fillAmount = 0;
            GameObject ringOfFireEffect = Instantiate(ringOfFirePrefab, player.transform.position, player.transform.rotation);
        }
        
    }

    public void inferno()
    {
        
        if (burningIsCoolDown == false)
        {
            burningIsCoolDown = true;
            burningCenterPic.enabled = false;

            burningPic.fillAmount = 0;
            GameObject burningEffect = Instantiate(burningPrefab, player.transform.position, player.transform.rotation);
        }
        
    }

    public void grappling()
    {
        
        if (grapplingIsCooldown == false)
        {
            grapplingIsCooldown= true;
            grapplingCenterPic.enabled = false;

            grapplingPic.fillAmount = 0;
            grapplingScript.BeginGrapple();
        }
        
    }

    public void rapidFire()
    {
        
        if (rapidFireIsCooldown == false)
        {
            rapidFireIsCooldown = true;
            rapidFireCenterPic.enabled = false;

            rapidFirePic.fillAmount = 0;
            shootingScript.rapidFire();
        }
        
    }

    public void electricity()
    {

    }

    public IEnumerator StartCooldown(float CooldownDuration)
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }
}
