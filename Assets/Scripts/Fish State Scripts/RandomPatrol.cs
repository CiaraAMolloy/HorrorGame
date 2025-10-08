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
    Vector3 goal ;

    private UnityEngine.AI.NavMeshAgent agent;
    //private Vector3 goal=new Vector3(Random.Range(0,50),Random.Range(0,50),1);
   
    //run
    public override State RunCurrentState()
    {
        
       agent =GameObject.FindGameObjectWithTag("fishman").GetComponent<UnityEngine.AI.NavMeshAgent>();
       
       //goal= GameObject.FindGameObjectWithTag("Player").transform.position;
    //goal =new Vector3(Random.Range(-100.0f,100.0f),4.08f,Random.Range(-100.0f,100.0f));
       
      // Debug.Log(goal);
        
     /*   if (false)
        {//if "sees" player
            return GGY ;
        }*/

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


        //agent.SetDestination(goal);


        return this;

    }


}
