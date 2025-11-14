using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonnaGetYou : State
{
    public RandomPatrol patrol;
    public Logic l;
    public Stunned s;
  private UnityEngine.AI.NavMeshAgent agent;
    Vector3 goal;

    public override State RunCurrentState()
    {
    agent = GameObject.FindGameObjectWithTag("fishman").GetComponent<UnityEngine.AI.NavMeshAgent>();
      var path = new UnityEngine.AI.NavMeshPath();
 
        if(l.getChasing())
        goal = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        // l.setChasing(true);

        

    if (!l.getChasing())
    {
      return patrol;
      
    }
     if (l.getisHit())
    {
      
      l.hitadressed();
      return s;


    }
         agent.CalculatePath(goal, path);
        switch (path.status)
        {
            case UnityEngine.AI.NavMeshPathStatus.PathComplete:
                
                agent.SetPath(path);
                break;
            case UnityEngine.AI.NavMeshPathStatus.PathPartial:
             agent.SetPath(path);
            
                break;
            default:
              
             
                break;
              
                
        }
      


        return this;

    }
}
