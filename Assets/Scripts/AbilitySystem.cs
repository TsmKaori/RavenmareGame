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

    bool basicBulletIsCoolDown;
    bool explodingProjectileIsCooldown;
    bool freezeIsCooldown;
    bool burningIsCoolDown;
    bool ringOfFireIsCooldown;
    bool grapplingIsCooldown;
    bool rapidFireIsCooldown;
    bool electricityIsCooldown;

    public float basicBulletCooldown = 1;
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
    public Image freezeCenterPic2;
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
        basicBulletIsCoolDown = false;
        explodingProjectileIsCooldown = false;
        freezeIsCooldown = false;
        burningIsCoolDown = false;
        ringOfFireIsCooldown = false;
        grapplingIsCooldown = false;
        rapidFireIsCooldown = false;
        
        unlockAbilties(SkillType.explodingProjectile);
        unlockAbilties(SkillType.freeze);

        Debug.Log(gameObject.transform.childCount);
    }



    // Update is called once per frame
    void Update()
    {
        UseAbility();

        if (Input.GetKeyDown(KeyCode.E) && basicBulletIsCoolDown != true)
        {
            //shootingScript.basicBullet();
            //StartCoroutine(StartCooldown(1f));
            shootBasicBullet();
        }

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
                freezeCenterPic2.enabled = true;
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
    
    void shootBasicBullet()
    {
        shootingScript.basicBullet();
        StartCoroutine(StartCooldown(1f));
    }

    public void unlockAbilties(SkillType skillName)
    {
        unlockedSkills.Add(skillName);

        
        if(skillName == SkillType.explodingProjectile)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (skillName == SkillType.freeze)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (skillName == SkillType.grappling)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (skillName == SkillType.ringOfFire)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (skillName == SkillType.rapidFire)
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
        }else if(skillName == SkillType.inferno)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void UseAbility()
    {
        if (IsAvailable == false)
        {
            return;
        }

        //Set up which one
        if (Input.GetKeyDown(KeyCode.Y))
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
    }

    public void useAbility2()
    {

    }

    public void useAbility3()
    {

    }

    public void explodingProjectile()
    {
        
        if(explodingProjectileIsCooldown == false && unlockedSkills.Contains(SkillType.explodingProjectile))
        {
            explodingProjectileIsCooldown = true;
            explodingProjectileCenterPic.enabled = false;

            explodingProjectilePic.fillAmount = 0;
            shootingScript.shoot();
        }
    }

    public void freeze()
    {
        
        if (freezeIsCooldown == false && unlockedSkills.Contains(SkillType.freeze))
        {
            freezeIsCooldown = true;
            freezeCenterPic.enabled = false;
            freezeCenterPic2.enabled = false;

            freezePic.fillAmount = 0;
            GameObject freezeEffect = Instantiate(freezePrefab, player.transform.position, player.transform.rotation);
        }
        
    }

    public void ringOfFire()
    {
        
        if (ringOfFireIsCooldown == false && unlockedSkills.Contains(SkillType.ringOfFire))
        {
            ringOfFireIsCooldown = true;
            ringOfFireCenterPic.enabled = false;

            ringOfFirePic.fillAmount = 0;
            GameObject ringOfFireEffect = Instantiate(ringOfFirePrefab, player.transform.position, player.transform.rotation);
        }
        
    }

    public void inferno()
    {
        
        if (burningIsCoolDown == false && unlockedSkills.Contains(SkillType.inferno))
        {
            burningIsCoolDown = true;
            burningCenterPic.enabled = false;

            burningPic.fillAmount = 0;
            GameObject burningEffect = Instantiate(burningPrefab, player.transform.position, player.transform.rotation);
        }
        
    }

    public void grappling()
    {
        
        if (grapplingIsCooldown == false && unlockedSkills.Contains(SkillType.grappling))
        {
            bool actuallyGrapple = grapplingScript.BeginGrapple();
            if(actuallyGrapple)
            {
                grapplingIsCooldown = true;
                grapplingCenterPic.enabled = false;

                grapplingPic.fillAmount = 0;
                grapplingScript.BeginGrapple();
            }
        }
        
    }

    public void rapidFire()
    {
        
        if (rapidFireIsCooldown == false && unlockedSkills.Contains(SkillType.rapidFire))
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
        basicBulletIsCoolDown = true;
        yield return new WaitForSeconds(CooldownDuration);
        basicBulletIsCoolDown = false;
    }
}
