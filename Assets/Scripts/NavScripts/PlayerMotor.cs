using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMotor : MonoBehaviour
{
    Transform target;       //Target to follow
    NavMeshAgent agent;     //reference to our agent

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        if(target != null){
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point){
        agent.SetDestination(point);
    }

    // public void FollowTarget(Interactable newTarget){
    //     agent.stoppingDistance = newTarget.radius * 0.75f;
    //     agent.updateRotation = false;

    //     target = newTarget.interactionTransform;
    // }

    public void StopFollowingTarget(){
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    void FaceTarget(){
        //direction to our target
        Vector3 direction = (target.position - transform.position).normalized;
        //ask for which direction we have to look
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        //slerp to this direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // " =lookRotation" woukd be the ez way
    }
}
