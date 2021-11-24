using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JarakPandang : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask; // Target pandang ke player
    public LayerMask obstructionMask; // Target yang menutupi sudut pandang

    public bool canSeePlayer;

    public GameObject _puzzle; //puzzle manager
    public GameObject _endPanel; //end progress

    public void Start()
    {

        _puzzle = GameObject.FindGameObjectWithTag("MainCamera");
        _endPanel = GameObject.FindGameObjectWithTag("EndPanel");
        
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    public IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    public void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;

                    if (canSeePlayer == true && _puzzle.activeSelf == false)
                    {
                        _endPanel.SetActive(true);
                        Debug.Log("Kamu Ketahuan");
                    }
                    
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
}
