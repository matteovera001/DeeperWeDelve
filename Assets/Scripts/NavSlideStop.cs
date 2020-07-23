using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavSlideStop : MonoBehaviour
{
    public float acceleration = 2f;
    public float deceleration = 60f;
    public float closeEnoughMeters = 4f;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (navMeshAgent)
        {

            // speed up slowly, but stop quickly
            if (navMeshAgent.hasPath)
                navMeshAgent.acceleration = (navMeshAgent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;

        }
    }

}
