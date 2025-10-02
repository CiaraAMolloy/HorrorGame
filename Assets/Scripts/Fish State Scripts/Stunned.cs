using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : State
{//what go
    public RandomPatrol Patrol;
    public int StunTime=10;
    public float Counter=0.0f;
    //run
    public override State RunCurrentState()
    {
        //this will go a certain length then back to patrol
        if (Counter < StunTime)
        {
            Counter += Time.deltaTime;
        }
        else
        {

            Counter = 0;
            return Patrol;
            //when the timer ends it patrols again

        }


        return this;

    }


}
