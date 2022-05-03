using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleAbility : MonoBehaviour
{
    [SerializeField] LineRenderer hook;
    [SerializeField] Transform playerTransform;
    //[SerializeField] 


    [SerializeField] LayerMask gappleMask;
    [SerializeField] float MaxDist = 5f;
    [SerializeField] float speed = 10f;
    [SerializeField] float shoTime = 20f;


    [SerializeField]
    private Animator playerAnimator;

    bool currentlyGappling = false;
    [HideInInspector] public bool retracting = false;

    [HideInInspector] public bool travel = false;

    //Vector2 direction;


    Vector2 hit;

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
            Vector2 grapplePosition = Vector2.Lerp(playerTransform.position, hit, speed * Time.deltaTime);
            playerTransform.position = grapplePosition;

            hook.SetPosition(0, playerTransform.position);

            if(Vector2.Distance(playerTransform.position, hit) < 0.5f)
            {
                retracting = false;
                currentlyGappling = false;
                hook.enabled = false;
            }

        }
    }

    public bool BeginGrapple()
    {
        Vector2 direction;
        if (playerAnimator.GetFloat("lastMoveX") < -0.1) //left facing
        {
            direction = Vector2.left;
        }
        else if (playerAnimator.GetFloat("lastMoveX") > 0.1) //right facing
        {
            direction = Vector2.right;
        }
        else if (playerAnimator.GetFloat("lastMoveY") > 0.1)  //Up facing
        {
            direction = Vector2.up;
        }
        else //down facing
        {
            direction = Vector2.down;
        }
        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

       RaycastHit2D tii = Physics2D.Raycast(playerTransform.position, direction, 5f, ~gappleMask);

        
        if (tii.collider)
        {
            hook.enabled = true;
            hook.positionCount = 2;
            currentlyGappling = true;
            this.hit = tii.point;

            StartCoroutine(currFly());
            return true;
        }
        else
        {
            return false;
        }
        
    }

    IEnumerator currFly()
    {
        float x = 0;
        float count = 10;

        hook.SetPosition(0, playerTransform.position);
        hook.SetPosition(1, playerTransform.position);

        Vector2 targetMove;

        for (; x < count; x += shoTime * Time.deltaTime)
        {
            targetMove = Vector2.Lerp(playerTransform.position, hit, x / count);
            hook.SetPosition(0, playerTransform.position);
            hook.SetPosition(1, targetMove);
            yield return null;
        }

        hook.SetPosition(1, hit);
        retracting = true;
    }
}
