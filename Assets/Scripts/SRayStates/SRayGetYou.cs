using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SRayGetYou : SRayState
{
    //different states itll transfer to
    public SRayPatrol patrol;
    public SRayStingYou sting;

    public GameObject SRay;
    public GameObject player;
    private NavMeshAgent agent;
    Vector3 goal;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
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

        //if ray is in contact with player, STING!
        //GET HIS ASS

        if (isPlayerContact) 
        {
            Debug.Log("SEIZE HIM!");
            return sting;
        }

        //if player gets away from stingray's range
        //stingray returns

        //if dist from patrol section > range, return patrol

        goal = GameObject.FindGameObjectWithTag("player").transform.position;
        //locates player, sets as destination

        transform.parent.parent.LookAt(player.transform.position);

        return this;
    }
}
