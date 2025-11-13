using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class SRayFSM : MonoBehaviour
{
    // current file allows for transitions between states for the sting rays (SRays!)
    public SRayState current;

    public Vector3 newRayDir = new Vector3(0f, 0f, 0f);
    public float newRaySpeed = 0f;

    public bool newIsGrounded = false;
    public bool newPlayerContact = false; // is enemy in contact with players
    public bool newRayContact = false; // is enemy is around other enemies
    public bool newPlayerSeen = false; // are bees seeing player
    RaycastHit ray; //what allows the bee to see the player in the first place

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        //current state passes its values onto new parameters once called
        SRayState next = current?.Run(newRayDir, newRaySpeed, newIsGrounded, newPlayerContact, newRayContact, newPlayerSeen);

        if (next != null)
        {
            newRayDir = current.rayDir;
            newRayDir = current.rayDir;
            newIsGrounded = current.isGrounded;
            newPlayerContact = current.isPlayerContact;
            newRayContact = current.isRayContact;
            newPlayerSeen = current.isPlayerSeen;
            current = next;
        }

    }

    public SRayState getCurrentState()
    {
        return current;
    }


    public string CurrentStateAsString
    {
        get
        {
            switch (current)
            {
                case SRayBirth:
                    return "the eggs are hatching";
                case SRayPatrol:
                    return "Swimmin";
                case SRayGetYou:
                    return "watch out man hes gonna getcha";
                case SRayStingYou:
                    return "oooh it stiiings";
                case SRayDeath:
                    return "oh one of em is dead";
            }
            return "Null";
        }
    }

    //triggers for the player having contact with the enemy
    //triggers already utilised in a different manner.
}