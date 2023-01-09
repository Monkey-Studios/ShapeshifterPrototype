using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DronePatrolSpecial : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject currentWaypoint;
    GameObject previousWaypoint;
    GameObject[] allWaypoints;
    bool travelling;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        allWaypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        currentWaypoint = GetRandomWaypoint();
        SetDestination();
    }


    void Update()
    {
        if (GetComponent<TargetingSpecial>().enabled)
        {
            travelling = false;
            switch (transform.gameObject.tag)
            {
                case "Enemy":
                    navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Invisible").transform.position);
                    break;
                case "SkyDrone":
                    navMeshAgent.SetDestination(transform.position);
                    break;
            }
        }
        else
        {
            if (!travelling)
            {
                SetDestination();
            }
        }

        if (travelling && navMeshAgent.remainingDistance <= 1f)
        {
            travelling = false;
            SetDestination();
        }
    }
    GameObject GetRandomWaypoint()
    {
        if (allWaypoints.Length == 0)
        {
            return null;
        }
        else
        {
            int index = Random.Range(0, allWaypoints.Length);
            return allWaypoints[index];
        }
    }
    void SetDestination()
    {
        previousWaypoint = currentWaypoint;
        currentWaypoint = GetRandomWaypoint();

        Vector3 targetVector = currentWaypoint.transform.position;
        navMeshAgent.SetDestination(targetVector);
        travelling = true;
    }
}
