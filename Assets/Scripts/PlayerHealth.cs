using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;
    public Logic l;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public int getcurrentHealth()
    {
        return currentHealth;
    }

    public void changeHealth(int amount)
    {
        //makes so that currentHealth cant go over maxHealth.
        currentHealth = Mathf.Clamp(currentHealth + amount, 0 , maxHealth); 
        Debug.Log(currentHealth + " HP / " + maxHealth + "HP");

        if (currentHealth == 0) //dead.
        {
            l.trigGameOver();
        }
    }
}
