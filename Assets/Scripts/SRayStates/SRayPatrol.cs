using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class SRayPatrol : SRayState
{
    //the states it'll swap to
    public SRayGetYou SRGY;

    // this is going to be the initial state the ray stays in.
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    public CanSeePlayer csp;

    private void Start()
    {
        //agent = GameObject.FindGameObjectWithTag("stingray").GetComponent<NavMeshAgent>();

        //Unity doc states disabling auto braking allows for continuous
        //movement btwn points (agent doesnt slow down when reaching point)
        agent.autoBraking = false;
    }

    public override SRayState Run()
    {
        return this;
    }

    public override SRayState Run(Vector3 rayDir, float raySpeed, bool isGrounded, bool isPlayerContact, bool isRayContact, bool isPlayerSeen)
    {
        this.rayDir = rayDir;
        this.isGrounded = isGrounded;
        this.isRayContact = isRayContact;
        this.isPlayerContact = isPlayerContact;
        this.isPlayerSeen = isPlayerSeen;

        
        if (csp.getisplseen())
        {
          //  goal = GameObject.FindGameObjectWithTag("Player").transform.position;
            return SRGY;

        } else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

        return this;
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    

    //has player entered radius

}
