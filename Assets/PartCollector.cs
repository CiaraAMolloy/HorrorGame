using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
     public Logic l;
    // Start is called before the first frame update
    void Start()
    { l = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + "collected a part");
        if (other.gameObject.name == "PlayerCapsule")
        {
            l.partcollected(gameObject.name);
            Destroy(this.gameObject);
        }

    }
    
}
