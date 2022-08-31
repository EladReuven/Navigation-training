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

    //private void Start()
    //{
    //    agent.SetDestination(followDestinations[currentWaypointIndex].position);
    //}

    private void Update()
    {
        if (!finishedRoute)
        {
            Debug.Log(agent.remainingDistance);
            if(!agent.pathPending)
            {
                if(agent.remainingDistance <= minDisForNextWaypoint)
                {
                GoToNextWayPoint();
                Debug.Log("remaining dis is smol");
                }
            }
        }
    }

    void GoToNextWayPoint()
    {
        Debug.Log(currentWaypointIndex);
        agent.SetDestination(followDestinations[currentWaypointIndex].position);
        currentWaypointIndex++;
        if(currentWaypointIndex >= followDestinations.Length)
        {
            if (looping)
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
