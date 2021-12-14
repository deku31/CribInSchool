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

    //animasi
    public Animator anim;

    // random
    public int random;

    public float defauldspeed;
    void Start()
    {
        volume = 0.3f;
        step = true;
        audiomanager = FindObjectOfType<SoundManager>();
        playermanager = FindObjectOfType<player>();

        agent = GetComponent<NavMeshAgent>();
        random = 0;
        defauldspeed = agent.speed;

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
            volume = 0.5f;
            if (mendekat == true&&playermanager._transfer==false)
            { 
                playermanager.peringatanObj.SetActive(true);
            }
            else if (mendekat == false && playermanager._transfer==false)
            {
                playermanager.peringatanObj.SetActive(false);
            }
            else
            {
                mendekat = false;
            }

        }
        if (Vector3.Distance(transform.position,target)<1)
        {
            if (random != 0)
            {
                agent.speed = 0;
                step = false;
                Invoke("jalan",3f);
            }
            if(random==0)
            {
                IterateWaypoint();
                UpdateDestination();
            }
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
    void jalan()
    {
        random = 0;
        agent.speed = defauldspeed;
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
        if (other.transform.tag=="point")
        {
            random = Random.Range(0,2);
            anim.SetBool("jalan", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "deteksiguru")
        {
            mendekat = false;
        }
        if (other.transform.tag == "point")
        {
            anim.SetBool("jalan", true);
        }
    }
}
