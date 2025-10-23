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
         agent =GameObject.FindGameObjectWithTag("fishman").GetComponent<UnityEngine.AI.NavMeshAgent>();
        goal= GameObject.FindGameObjectWithTag("Player").transform.position;
       // l.setChasing(true);

       
        if (!l.getChasing())
        { //After player gets away/time gone
//l.setChasing(false);
            return patrol;
            
        }
        else if(l.getisHit()){
        //    l.setChasing(false);
            l.hitadressed();
            return s;


        }
      


        return this;

    }
}
