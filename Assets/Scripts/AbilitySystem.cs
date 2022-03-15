using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{
    public GameObject freezePrefab;
    public GameObject ringOfFirePrefab;
    public GameObject burningPrefab;
    private shooting shootingScript;
    [SerializeField]
    private GameObject player;

    public bool IsAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        shootingScript = gameObject.GetComponent<shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        UseAbility();
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
            shootingScript.shoot();
            StartCoroutine(StartCooldown(6));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject freezeEffect = Instantiate(freezePrefab, player.transform.position, player.transform.rotation);
            StartCoroutine(StartCooldown(6));
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject ringOfFireEffect = Instantiate(ringOfFirePrefab, player.transform.position, player.transform.rotation);
            StartCoroutine(StartCooldown(6));
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject ringOfFireEffect = Instantiate(burningPrefab, player.transform.position, player.transform.rotation);
            StartCoroutine(StartCooldown(6));
        }
    }

    public IEnumerator StartCooldown(float CooldownDuration)
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }
}
