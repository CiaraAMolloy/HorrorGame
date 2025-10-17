using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{   public Logic l;
void Start()
    {
        l = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    }
    
    public void OnTriggerEnter(Collider c){
         Debug.Log("I can smell you");
        l.setChasing(true);
    }
    public void OnTriggerExit(Collider c){
        Debug.Log("where go?");
        l.setChasing(false);
    }
}
