using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeacherAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] wayPoint;
    int wayPoitIndex;
    Vector3 target;
    bool step;
    //audio manager
    private SoundManager audiomanager;
    private float volume;
    private float pitch;
    bool mendekat;
    //player manager
    private player playermanager;
    void Start()
    {
        pitch = 1;
        volume = 0.3f;
        step = true;
        audiomanager = FindObjectOfType<SoundManager>();
        playermanager = FindObjectOfType<player>();

        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (step == true)
        {
            Invoke("stepSound", 0.8f);
            step = false;
        }
        if (playermanager.munculPuzzle==true)
        {
            pitch =1.20f;
            if (mendekat == true && volume < 1)
            {
                volume +=0.3f*Time.deltaTime;
            }
            else if (mendekat == false && volume > 0.3f)
            {
                volume -= Time.deltaTime;
            }
        }
        else
        {
            volume = 0.5f;
            pitch = 1;
        }
        if (Vector3.Distance(transform.position,target)<1)
        {
            IterateWaypoint();
            UpdateDestination();
        }
    }
    void stepSound()
    {
        audiomanager.guruWalkMethod(volume,pitch);
        step = true;
    }
    void UpdateDestination()
    {
        target = wayPoint[wayPoitIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypoint()
    {
        wayPoitIndex++;
        if (wayPoitIndex==wayPoint.Length)
        {
            wayPoitIndex = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Player")
        {
            mendekat = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            mendekat = false;
        }
    }
}
