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
    bool mendekat;
    //player manager
    private player playermanager;
    void Start()
    {
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
            Invoke("stepSound", 1.5f-agent.speed);
            step = false;
        }
        if (playermanager.munculPuzzle==true)
        {
            if (mendekat == true && volume < 1)
            {
                playermanager.peringatanObj.SetActive(true);
                volume += 1;
            }
            else if (mendekat == false && volume > 0.3f)
            {
                playermanager.peringatanObj.SetActive(false);
                volume -= Time.deltaTime;
            }
        }
        else
        {
            mendekat = false;
            playermanager.peringatanObj.SetActive(false);
            volume = 0.5f;
        }
        if (Vector3.Distance(transform.position,target)<1)
        {
            IterateWaypoint();
            UpdateDestination();
        }
    }
    void stepSound()
    {
        audiomanager.guruWalkMethod(volume);
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
        if (other.transform.tag=="deteksiguru")
        {
            mendekat = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "deteksiguru")
        {
            mendekat = false;
        }
    }
}
