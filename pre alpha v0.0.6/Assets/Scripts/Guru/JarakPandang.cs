using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JarakPandang : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public Vector3 currentRotation;
    public Vector3 anglesRotate; //kecepatan rotasi

    public GameObject playerRef;

    public LayerMask targetMask; // Target pandang ke player
    public LayerMask obstructionMask; // Target yang menutupi sudut pandang

    public bool canSeePlayer;

    public GameObject _puzzle; //puzzle manager
    public GameObject _endPanel; //end progress


    public void Start()
    {
        _puzzle = FindInActiveObjectByName("PuzzleManager");

        _endPanel = FindInActiveObjectByTag("EndPanel");

        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

        //---------------------------------------------------------
        //Rotasi
        //currentRotation = new Vector3(currentRotation.x, currentRotation.y +Time.deltaTime, currentRotation.z);
        this.transform.eulerAngles = currentRotation;
    }

    public void Update()
    {

        currentRotation = currentRotation + anglesRotate * Time.deltaTime;
        currentRotation = new Vector3(currentRotation.x, currentRotation.y, currentRotation.z);
        this.transform.eulerAngles = currentRotation;
    }

    GameObject FindInActiveObjectByName(string name) //fungsi mencari object yang tidak aktif menggunakan nama
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    GameObject FindInActiveObjectByTag(string tag) //fungsi mencari object yang tidak aktif menggunakan tag
    {
        
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    
                    return objs[i].gameObject;
                }
            }
        }
        return null;
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

                    if (canSeePlayer == true && _puzzle.activeSelf == true)
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
