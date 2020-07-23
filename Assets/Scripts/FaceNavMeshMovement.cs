using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FaceNavMeshMovement : MonoBehaviour
{
    //Credit:
    //https://thehangarter.wordpress.com/2017/05/25/rotating-the-character-with-navmeshagent-navigation/
    NavMeshAgent agent;
    Quaternion oldRot;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        transform.rotation = oldRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (/*!agent.isStopped*/true)
        {
            var targetPosition = agent.pathEndPosition;
            var targetPoint = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            var _direction = (targetPoint - transform.position).normalized;
            var _lookRotation = Quaternion.LookRotation(_direction);

            //OLD

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360);

            //New
            

            Quaternion possibleRot = Quaternion.RotateTowards(transform.rotation, _lookRotation, 360); 
            if (possibleRot.y==0)
            {
                transform.rotation = oldRot;
            }
            else
            {
                transform.rotation = possibleRot;
            }

            

            oldRot = transform.rotation;
            
        }
    }
}
