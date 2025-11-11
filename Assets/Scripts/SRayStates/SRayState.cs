using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SRayState : MonoBehaviour
{
    public Vector3 rayDir = new Vector3(0f, 0f, 0f);
    public float raySpeed = 0f;

    public bool isGrounded = false;
    public bool isPlayerContact = false; // is enemy in contact with players
    public bool isRayContact = false; // is enemy is around other enemies
    public bool isPlayerSeen = false; // are bees seeing player

    public abstract SRayState Run();
    public abstract SRayState Run(Vector3 rayDir, float raySpeed, bool isGrounded, bool isPlayerContact, bool isRayContact, bool isPlayerSeen);
}
