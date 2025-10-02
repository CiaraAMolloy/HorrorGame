using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToSound : State
{
     //put the states it goes to here
   // public BloodSeek BS; not gonna go to this 
   
    public GonnaGetYou GGY;
    public RandomPatrol Patrol;

    //run
    public override State RunCurrentState()
    {
        if (false)
        {
            //if "sees" player
            return GGY;
        }
        if (false)
        { //After find sound patrol
            return patrol;
            
        }
      


        return this;

    }

}
