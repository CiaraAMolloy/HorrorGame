using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeePlayer : MonoBehaviour
{
    public Logic l;
    public bool isPlayerSeen;
    void Start()
    {
        l = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    public void OnTriggerEnter(Collider src)
    {
        if (src.gameObject.name == "PlayerCapsule")
        {
            Debug.Log("ooooh imma getcha");
            isPlayerSeen=true;
        }
    }

    public void OnTriggerExit(Collider src)
    {
        if (src.gameObject.name == "PlayerCapsule")
        {
            Debug.Log("back to patrol");
            isPlayerSeen=false;
        }
    }
    public bool getisplseen() {
        return isPlayerSeen;
    }
}
