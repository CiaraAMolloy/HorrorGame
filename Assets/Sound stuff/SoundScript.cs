using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{   public Collider sphere;
    public double Volume;//=new Vector3 (100,100,100);
    public Vector3 distance;
    public GameObject Fishman;

    // Start is called before the first frame update
    void Start()
    {
     Fishman = GameObject.FindGameObjectWithTag("fishman");
      distance= Fishman.transform.position-this.transform.position;
     //sphere.transform.localScale=Volume; do this in spawn script
    //Debug.Log(sphere.transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }//spawnscript has to have a size value
}
