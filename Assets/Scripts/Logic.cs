using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
   public bool HeardASound;
   public Vector3 mostRecentsound;
    List<GameObject> unheardsounds;
   public float sus = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void trigGameOver()
    {
        Debug.Log("Game Over");
    }


    public void RestartGame()
    {     Debug.Log("button press");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   
    }

    public bool GetHeardsound()
    {return HeardASound;}
    public Vector3 GetmostRecentsound()
    {return mostRecentsound;}

    public void setHeardsound(bool tf,Vector3 posOfHS)
    {
        HeardASound = tf;
        mostRecentsound=posOfHS;

     }
      public void setHeardsoundFalse()
    {
        HeardASound = false;
        
     }

    public float getSus(){
        return sus;
    }
    public void AddSus(float time){
        sus+=time;
    }
}
