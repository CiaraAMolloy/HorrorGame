using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : State
{

    //put the states it goes to here
    public BloodSeek BS;
    public GoToSound GTS;
    public GonnaGetYou GGY;

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
        else if (false)
        { //if find blood
            return BS;
         }


        return this;

    }


}
