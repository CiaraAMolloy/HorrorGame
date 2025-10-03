using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{  // public Collider sphere;
    public float Volume;//only one that needs assigning
    public float distance;
    public GameObject Fishman;
    public float desire;
    public Logic l;

    // Start is called before the first frame update
    void Start()
    {
    
    l= GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
     Fishman = GameObject.FindGameObjectWithTag("fishman");
     distance= Vector3.Distance(Fishman.transform.position, this.transform.position);

    //vol*sus/distance
 float sus = l.getSus();
    desire= ((Volume+sus)/distance);
    //need to experiment  *l.getSus()
   
    Debug.Log(Volume+"/"+distance+"="+"desire"+desire);
       if (desire > 5.0f)
    {
      Debug.Log("hears a sound");
    }
    else { Debug.Log(Volume + " ," + distance); }
    }

    // Update is called once per frame
    void Update()
    {
        

    }//spawnscript has to have a size value
}
