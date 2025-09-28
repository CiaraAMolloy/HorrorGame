using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundspawner : MonoBehaviour
{
      public GameObject Sound;
    // Start is called before the first frame update
    void Start()
    {
        //n/a
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnSound(float volume,Vector3 soundLocal){
//volume==scale
       GameObject newObject = Instantiate(Sound,soundLocal, transform.rotation) as GameObject;
       newObject.transform.localScale = new Vector3(volume,volume,volume); // change its local scale in x y z format



    }
}
