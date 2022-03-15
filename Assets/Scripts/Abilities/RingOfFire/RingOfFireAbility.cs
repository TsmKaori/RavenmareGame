using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfFireAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillOnAnimationEnd());
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
