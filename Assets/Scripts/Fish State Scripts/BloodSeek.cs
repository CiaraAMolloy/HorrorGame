using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class BloodSeek: State
{
    public GoToSound GTS;
    public GonnaGetYou GGY;
    public RandomPatrol patrol;
    public NavMeshAgent agent;
    public Logic L;
    public float searchInterval = 1f;
    private float searchTimer;
    private GameObject target;


    void Awake()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }
    void OnEnable()
    {
        searchTimer = 0f;
    }

    void Update()
    {
        searchTimer -= Time.deltaTime;
        if (searchTimer <= 0f)
        {
            searchTimer = searchInterval;
            FindTargetBlood();
        }

        if (target != null)
        {
            agent.SetDestination(target.transform.position);

            
            if (target == null || Vector3.Distance(transform.position, target.transform.position) < 1f)
            {
                target = null;
                // TODO: Transition to another state here
            }
        }
    }

    void FindTargetBlood()
    {
        GameObject best = null;
        float closest = Mathf.Infinity;

        float lifetime = L.bloodLifetime;
        float initialRange = L.initialDetectionRange;
        float minRange = L.minDetectionRange;

        foreach (var (blood, spawnTime) in BloodDrip.activeBlood)
        {
            if (blood == null) continue;

            float range = BloodDrip.GetCurrentDetectionRange(spawnTime, lifetime, initialRange, minRange);
            float dist = Vector3.Distance(transform.position, blood.transform.position);

            if (dist < range && dist < closest)
            {
                closest = dist;
                best = blood;
            }
        }

        target = best;
    }

    //run
    public override State RunCurrentState()
{
    if (GGY != null && L != null && L.getChasing())
    {
        Debug.Log("Switching to GGY");
        return GGY;
    }

    if (target == null)
    {
        Debug.Log("Switching to Patrol");
        return patrol;
    }

    if (Vector3.Distance(transform.position, target.transform.position) < 1.5f)
    {
        Debug.Log("Blood found, going to patrol");
        return patrol;
    }

    return this;
}

}
