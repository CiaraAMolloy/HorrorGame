using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{   public Collider sphere;
    private Vector3 Volume;//=new Vector3 (100,100,100);

    // Start is called before the first frame update
    void Start()
    {
     //sphere.transform.localScale=Volume; do this in spawn script
    //Debug.Log(sphere.transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }//spawnscript has to have a size value
}
