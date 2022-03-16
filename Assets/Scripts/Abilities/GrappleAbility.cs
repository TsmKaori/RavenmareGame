using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleAbility : MonoBehaviour
{
    [SerializeField] LineRenderer hook;
    [SerializeField] Transform playerTransform;


    [SerializeField] LayerMask gappleMask;
    [SerializeField] float MaxDist = 10f;
    [SerializeField] float speed = 10f;
    [SerializeField] float shootSpeed = 20f;

    [SerializeField]
    private Animator playerAnimator;

    bool currentlyGappling = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        //hook = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.U) && !currentlyGappling)
        if (Input.GetKeyDown(KeyCode.U) && !currentlyGappling)
        {
            BeginGrapple();
        }

        if (retracting)
        {
            Vector2 grapplePosition = Vector2.Lerp(playerTransform.position, target, speed * Time.deltaTime);
            playerTransform.position = grapplePosition;

            hook.SetPosition(0, playerTransform.position);

            if(Vector2.Distance(playerTransform.position, target) < 0.5f)
            {
                retracting = false;
                currentlyGappling = false;
                hook.enabled = false;
            }

        }
    }
    public void BeginGrapple()
    {
        Vector2 direction;
        if (playerAnimator.GetFloat("lastMoveX") < -0.1) //left facing
        {
            direction = new Vector2(10, 0);
        }
        else if (playerAnimator.GetFloat("lastMoveX") > 0.1) //right facing
        {
            direction = new Vector2(-10, 0);
        }
        else if (playerAnimator.GetFloat("lastMoveY") > 0.1)  //Up facing
        {
            direction = new Vector2(0, -10);
        }
        else //down facing
        {
            direction = new Vector2(0, 10);
        }
        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;



        RaycastHit2D hit = Physics2D.Raycast(playerTransform.position,direction,MaxDist,gappleMask);
        Debug.Log(direction);

        if (hit.collider == null)
        {
            currentlyGappling = true;
            target = (Vector2)playerTransform.position - direction;
            Debug.Log(target);
            hook.enabled = true;
            hook.positionCount = 2;

            StartCoroutine(Grappling());
        }
    }

    IEnumerator Grappling()
    {
        float x = 0;
        float time = 10;

        hook.SetPosition(0, playerTransform.position);
        hook.SetPosition(1, playerTransform.position);

        Vector2 newPosition;

        for (; x < time; x += shootSpeed * Time.deltaTime)
        {
            newPosition = Vector2.Lerp(playerTransform.position, target, x / time);
            hook.SetPosition(0, playerTransform.position);
            hook.SetPosition(1, newPosition);
            yield return null;
        }

        hook.SetPosition(1, target);
        retracting = true;
    }
}
