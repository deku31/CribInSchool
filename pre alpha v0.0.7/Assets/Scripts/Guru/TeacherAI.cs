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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,target)<1)
        {
            IterateWaypoint();
            UpdateDestination();
        }
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
}
