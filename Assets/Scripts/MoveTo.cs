using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("MoveTo: No NavMeshAgent on this GameObject.");
            enabled = false;
            return;
        }
        if (goal != null)
        {
            agent.destination = goal.position;
        }
        else
        {
            Debug.LogWarning("MoveTo: Goal not set in Inspector.");
        }
    }
}
