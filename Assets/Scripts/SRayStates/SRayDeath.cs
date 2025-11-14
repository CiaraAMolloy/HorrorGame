using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRayDeath : SRayState
{
    public GameObject stingray;

    private bool stung = false; 

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

        //moving stinging to here.
        if (stung == false)
        {
            Debug.Log("player's been stung! yeowch!");
            //player takes 5 damage
            stung = true;

            //if stung = true, death state.
            if (stung == true)
            {
                Debug.Log("STINGRAY DOWN");
                DespawnSRay();
            }
        }

        return this;
    }

    public void DespawnSRay()
    {
        Destroy(this.transform.parent.transform.parent.gameObject);
    }
}
