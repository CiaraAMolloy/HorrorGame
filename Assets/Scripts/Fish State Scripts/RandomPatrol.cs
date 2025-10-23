using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RandomPatrol : State
{

    //put the states it goes to here
    public BloodSeek BS;
    public GoToSound GTS;
    public GonnaGetYou GGY;

    public Logic L;
   //Vector3 goal  ;

    private UnityEngine.AI.NavMeshAgent agent;
    public Vector3 goal=new Vector3(0f,0f,0f);
   
    //run
    public override State RunCurrentState()
    {

        agent = GameObject.FindGameObjectWithTag("fishman").GetComponent<UnityEngine.AI.NavMeshAgent>();

       // goal=   new Vector3(Random.Range(-28.0f, 28.0f), 4.08f, Random.Range(-30.0f, 30.0f));
            
      //  Debug.Log( Vector3.Distance(goal,GameObject.FindGameObjectWithTag("fishman").transform.position));
        
      // Debug.Log(goal);
        
       if (L.getChasing())
        {//if "sees" player
        L.setHeardsoundFalse();
            return GGY ;
        }

        if (L.GetHeardsound())
        {//if hear sound
        L.setHeardsoundFalse();
        
            return GTS;
        }
        /*
        if (false)
        { //if find blood
            return BS;
        }*/
       // goal= GameObject.FindGameObjectWithTag("Player").transform.position;
if (agent.remainingDistance==0) {
            goal = new Vector3(Random.Range(-28.0f, 23.0f), 4.08f, Random.Range(-30.0f, 30.0f));
            Debug.Log("new goal");
        }

        agent.SetDestination(goal);


        return this;

    }


}
