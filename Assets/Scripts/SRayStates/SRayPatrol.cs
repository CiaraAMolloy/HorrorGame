using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SRayPatrol : SRayState
{
    //the states it'll swap to
    public SRayGetYou SRGY;

    // this is going to be the initial state the ray stays in.
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

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

        agent = GameObject.FindGameObjectWithTag("stingray").GetComponent<NavMeshAgent>();

        //Unity doc states disabling auto braking allows for continuous
        //movement btwn points (agent doesnt slow down when reaching point)
        agent.autoBraking = false;

        //chooses new point if nearby current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        
        if (isPlayerSeen)
        {
          //  goal = GameObject.FindGameObjectWithTag("Player").transform.position;
          return SRGY;
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
