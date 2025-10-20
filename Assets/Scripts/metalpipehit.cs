using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metalpipehit : MonoBehaviour
{ public Logic l;


    // Start is called before the first frame update
    void Start()
    { 
         l = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    }

    // Update is called once per frame
   /* void Update()
    {
       
    }*/

    void OnTriggerStay(Collider c){
       // Debug.Log("in range ");
        if (Input.GetKeyDown("u"))
        {
       // Debug.Log("u key was pressed");
        l.hit(); 
       // clang.Play();
        }
    }
}
