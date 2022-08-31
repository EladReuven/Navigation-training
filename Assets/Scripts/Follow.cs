using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public Transform[] followDestinations;
    public NavMeshAgent agent;

    public float minDisForNextWaypoint;
    public int currentWaypointIndex = 0;
    public bool looping = true, finishedRoute = false;

    private void Update()
    {
        while(!finishedRoute)
        {
            if(agent.remainingDistance <= minDisForNextWaypoint)
            {
                GoToNextWayPoint();
            }
        }
    }

    void GoToNextWayPoint()
    {
        agent.SetDestination(followDestinations[currentWaypointIndex].position);
        currentWaypointIndex++;
        if(currentWaypointIndex >= followDestinations.Length)
        {
            if(looping)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                finishedRoute = true;
            }
        }
    }
}
