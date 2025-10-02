using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : State
{

    //put the states it goes to here
    public BloodSeek BS;
    public GoToSound GTS;
    public GonnaGetYou GGY;

    public Logic L;

    //run
    public override State RunCurrentState()
    {
        if (false)
        {//if "sees" player
            return GGY;  
        }
         if (L.GetHeardsound())
        {//if hear sound
            return GTS;
        }
         if (false)
        { //if find blood
            return BS;
         }


        return this;

    }


}
