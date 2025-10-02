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
   public void spawnSound(float volume,Vector3 where ){
//volume==scale
       GameObject s = Instantiate(Sound, where, transform.rotation) as GameObject;
      s.GetComponent<SoundScript>().Volume =volume ;
    


    }
}
