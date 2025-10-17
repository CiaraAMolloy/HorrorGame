using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSound : State
{
     //put the states it goes to here
   // public BloodSeek BS; not gonna go to this 
   
    public GonnaGetYou GGY;
    public RandomPatrol Patrol;
    public Logic l;
    private UnityEngine.AI.NavMeshAgent agent;
    Vector3 thispos;

    //run
    public override State RunCurrentState()
    {       agent =GameObject.FindGameObjectWithTag("fishman").GetComponent<UnityEngine.AI.NavMeshAgent>();

        thispos=GameObject.FindGameObjectWithTag("fishman").transform.position;
        
        if (l.getChasing())
        {
            //if "sees" player
            return GGY;
        }
       
        Vector3 goal=l.GetmostRecentsound();
//Debug.Log(goal);
//Debug.Log(Vector3.Distance(goal, thispos));
// operator ==(Vector3 lhs, Vector3 rhs)

        if ( Vector3.Distance(goal, thispos)<2)
        { //After find sound patrol
       // Debug.Log("yay");
            return Patrol;
            
        }
        agent.SetDestination(goal);

      


        return this;

    }

}
