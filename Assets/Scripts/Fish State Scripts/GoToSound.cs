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
    Vector3 goal;

    bool pathpossible;
    void start()
    {
        
    }

    //run
    public override State RunCurrentState()
    {
        var path = new UnityEngine.AI.NavMeshPath();
    
        agent =GameObject.FindGameObjectWithTag("fishman").GetComponent<UnityEngine.AI.NavMeshAgent>();

        thispos=GameObject.FindGameObjectWithTag("fishman").transform.position;
        
        if (l.getChasing())
        {
            //if "sees" player
            return GGY;
        }


        //pathpossible = agent.CalculatePath(l.GetmostRecentsound(), path);
         agent.CalculatePath(l.GetmostRecentsound(), path);
        switch (path.status)
        {
            case UnityEngine.AI.NavMeshPathStatus.PathComplete:
                
                agent.SetPath(path);
                goal = l.GetmostRecentsound();
                break;
            case UnityEngine.AI.NavMeshPathStatus.PathPartial:
               // Debug.Log("partial path.");
                // return Patrol;      
                  
                break;
            default:
                //return Patrol;
                break;
              
                
        }


        if (Vector3.Distance(goal, thispos) < 2)
        {
            return Patrol;

        }

     


        return this;

    }

}
