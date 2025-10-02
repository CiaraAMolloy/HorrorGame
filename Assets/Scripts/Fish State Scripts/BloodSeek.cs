using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSeek : State
{
    

    //put the states it goes to here
    
    public GoToSound GTS;
    public GonnaGetYou GGY;
    public RandomPatrol patrol;


    //run
    public override State RunCurrentState()
    {
        if (false)
        {//if "sees" player
            return GGY;
        }
        else if (false)
        {//if hear sound
            return GTS;
        }
        if (false)
        { //After player gets away/time gone
            return patrol;

        }



        return this;

    }
}
