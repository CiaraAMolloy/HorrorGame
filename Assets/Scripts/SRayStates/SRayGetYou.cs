using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SRayGetYou : SRayState
{
    //different states itll transfer to
    public SRayPatrol patrol;
    public SRayDeath sting;

    public GameObject stingray;
    public GameObject player;
    private NavMeshAgent agent;
    Vector3 goal;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GameObject.FindGameObjectWithTag("stingray").GetComponent<NavMeshAgent>();
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

        //if player gets away from stingray's range
        //stingray goes back to patrol

       // if (isPlayerSeen)
        //{
            goal = GameObject.FindGameObjectWithTag("Player").transform.position;
       // }
            var path = new UnityEngine.AI.NavMeshPath();
        //locates player, sets as destination

        //creates a path for locating player to follow them

        agent.CalculatePath(goal, path);
        switch (path.status)
        {
            case UnityEngine.AI.NavMeshPathStatus.PathComplete: //stingray gets you
                agent.SetPath(path);
                break;
            case UnityEngine.AI.NavMeshPathStatus.PathPartial: // can only get a certain point
                agent.SetPath(path);
                break;
            case UnityEngine.AI.NavMeshPathStatus.PathInvalid: //cant get you
                //agent.SetPath(path);
               // return patrol;
            default:
                break;
        }

        transform.parent.parent.LookAt(player.transform.position);

        //here is the actual. oh wow player got touched thing
        if (isPlayerContact)
        {
            return sting; //swaps to sting state
        }

            return this;
    }
}
