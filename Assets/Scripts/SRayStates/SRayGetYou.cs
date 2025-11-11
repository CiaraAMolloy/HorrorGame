using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRayGetYou : SRayState
{
    public GameObject SRay;
    public GameObject player;

    // to be fair, this isnt really too necessary for just exclusively the rays
    // but it helps it so that if the rays are stuck in a something,
    // they just retreat to this then they're capable of switching yet again.

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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

        return this;
    }
}
