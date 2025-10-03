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
    public float threshold=0.5f;

  //public GameObject sound;

  // Start is called before the first frame update
  void Start()
  {
    //sound=GameObject.FindGameObjectWithTag("sound").GetComponent<sound>();

    l = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    Fishman = GameObject.FindGameObjectWithTag("fishman");
    distance = Vector3.Distance(Fishman.transform.position, this.transform.position);

    //vol*sus/distance
    float sus = l.getSus();
    desire = ((Volume + sus) / distance);
    //need to experiment  *l.getSus()

    //Debug.Log(Volume+"/"+distance+"="+"desire"+desire);
    if (desire > threshold)
    {
      Debug.Log("hears a sound");
      l.setHeardsound(true);
    }
    else
    {
      Debug.Log("does not hears a sound");

      //Destroy(this);
    }
    
    }

    // Update is called once per frame
    void Update()
    {
    //Destroy(this);

    }//spawnscript has to have a size value
}
