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
        Debug.Log(collision.gameObject.name);
        

        if (collision.gameObject.name == "Fishmancollider")
        {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            Debug.Log("AAAAAAh dead");
            l.trigGameOver();
        }

  if (collision.gameObject.tag == "stingray") {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            Debug.Log("Damage taken!");

            currentHealth.changeHealth(-5);
        }

    }
    private void  OnTriggerEnter(Collider collision)//exit or stay
    {
        Debug.Log(collision.gameObject.name);
        

      /*  if (collision.gameObject.name == "Fishmancollider")
        {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            Debug.Log("AAAAAAh dead");
            l.trigGameOver();
        }*/

     /*   if (collision.gameObject.name == "stingray") {
            Debug.Log("Entered collision with " + collision.gameObject.name);
            Debug.Log("Damage taken!");

            currentHealth.changeHealth(-5);
        }*/

    }
    
    
   
    
}
