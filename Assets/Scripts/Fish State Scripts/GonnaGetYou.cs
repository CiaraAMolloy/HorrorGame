using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GonnaGetYou : State
{
    public RandomPatrol patrol;
    public override State RunCurrentState()
    {
       
        if (false)
        { //After player gets away/time gone
            return patrol;
            
        }
      


        return this;

    }
}
