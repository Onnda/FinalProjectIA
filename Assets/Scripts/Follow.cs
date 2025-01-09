using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // The target to follow

    [Header("Follow Settings")]
    public float followDistance = 2.0f; // Minimum distance to maintain from the target

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (target != null && agent != null)
        {
            // Calculate the distance to the target
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // If the distance is greater than the follow distance, set the target position
            if (distanceToTarget > followDistance)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                // Stop moving when within the follow distance
                agent.ResetPath();
            }
        }
    }
}
