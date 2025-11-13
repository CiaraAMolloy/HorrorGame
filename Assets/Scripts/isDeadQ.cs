using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDeadQ : MonoBehaviour
{
    public Logic l;
    public PlayerHealth currentHealth;
    void Start()
    {
        l = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    }

    private void OnCollisionEnter(Collision collision)//exit or stay
    {
        

        if (collision.gameObject.name == "Fishmancollider")
        {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            Debug.Log("AAAAAAh dead");
            l.trigGameOver();
        }

        if (collision.gameObject.name == "sraycollider") {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            Debug.Log("Damage taken!");

            currentHealth.changeHealth(-5);
        }

    }
    
    
   
    
}
