using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRayStingYou : SRayState
{
    //to see whether it should return to whichever state below
    public SRayPatrol SRPtrl;
    public SRayGetYou SRGY;
    public SRayDeath SRD;

    private bool stung = false; //to see if the player has been stung

    public override SRayState Run()
    {
        return this;
    }

    public override SRayState Run(Vector3 rayDir, float raySpeed, bool isGrounded, bool isPlayerContact, bool isRayContact, bool isPlayerSeen)
    {
        this.rayDir = rayDir;
        this.isGrounded = isGrounded;
        this.isRayContact = isRayContact;
        this.isPlayerContact = isPlayerContact;
        this.isPlayerSeen = isPlayerSeen;

        if (stung == false)
        {
            Debug.Log("player's been stung! yeowch!");
            //player takes 5 damage
            stung = true;

            //if stung = true, death state.
            if (stung == true)
            {
                return SRD;
            }
        }

        return this;
    }
}
