using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Transform trackedAgent;
   public bool HeardASound;
   public Vector3 mostRecentsound;
    List<GameObject> unheardsounds;

    string[] PartsCollected = new string[5];
    int numberofpartscollected = 0;
   public float sus = 1;

   bool chasing=false;
   bool isHit=false;
    public AudioSource clang;

    private bool bloodDetected = false;
    public float bloodLifetime = 10f;
    public float initialDetectionRange = 20f;
    public float minDetectionRange = 2f;
    public float bloodCheckInterval = 0.5f;
    private float bloodCheckTimer = 0f;



public void hit(){
if(chasing){
    isHit=true;
    clang.Play();
}}
public void hitadressed(){
    isHit=false;
}

public bool getisHit(){
    return isHit;
}
     


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for nearby blood every few frames
        bloodCheckTimer -= Time.deltaTime;
        if (bloodCheckTimer <= 0f)
        {
            bloodCheckTimer = bloodCheckInterval;
            bloodDetected = IsBloodNearby();
        }
    }

    public void partcollected(string name)
    {
        Debug.Log("collected" + name);
        PartsCollected[numberofpartscollected]=name;
        numberofpartscollected++;

    }
    public void trigGameOver()
    {
        Debug.Log("Game Over");
       // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
       public void retry()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }


    public void RestartGame()
    {   Debug.Log("button press");
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


    public void setChasing(bool tf){
        chasing=tf;
    }

    public bool getChasing()
    {
        return chasing;
    }
    
    bool IsBloodNearby()
    {
        if (BloodDrip.activeBlood == null || BloodDrip.activeBlood.Count == 0)
        {
            Debug.Log("No active blood objects in list.");
            return false;
        }

        foreach (var (blood, spawnTime) in BloodDrip.activeBlood)
        {
            if (blood == null) continue;

            float range = BloodDrip.GetCurrentDetectionRange(
                spawnTime,
                bloodLifetime,
                initialDetectionRange,
                minDetectionRange
            );

            float distance = Vector3.Distance(trackedAgent.position, blood.transform.position);
            Debug.Log($"Checking blood at {distance:F2}m (range {range:F2})");

            if (distance < range)
            {
                Debug.Log("Blood detected!");
                return true;
            }
        }

        Debug.Log("No blood in range.");
        return false;
    }


    public bool GetBloodDetected()
    {
        return bloodDetected;
    }

        void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, initialDetectionRange);
    }

}
