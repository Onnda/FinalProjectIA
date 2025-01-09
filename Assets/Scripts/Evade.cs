using UnityEngine;
using UnityEngine.AI;

public class EvadeFollower : MonoBehaviour
{
    [Header("Evade Settings")]
    public Transform follower; // The follower to evade

    public float safeDistance = 5.0f; // Distance to maintain from the follower
    public float evadeSpeedMultiplier = 1.5f; // Speed multiplier when evading

    private NavMeshAgent agent;
    private Vector3 evadeDirection;

    void Start()
    {
        // Get the NavMeshAgent component attached to the character
        agent = GetComponent<NavMeshAgent>();

       
    }

    void Update()
    {
        if (follower != null && agent != null)
        {
            // Calculate the distance to the follower
            float distanceToFollower = Vector3.Distance(transform.position, follower.position);

            // If the follower is too close, calculate an evade direction
            if (distanceToFollower < safeDistance)
            {
                // Calculate the direction away from the follower
                evadeDirection = (transform.position - follower.position).normalized;

                // Determine the evade position
                Vector3 evadePosition = transform.position + evadeDirection * safeDistance;

                // Temporarily increase the agent's speed for evading
                agent.speed *= evadeSpeedMultiplier;

                // Move the agent to the evade position
                agent.SetDestination(evadePosition);
            }
            else
            {
                // Reset the agent's speed to default when not evading
                agent.speed /= evadeSpeedMultiplier;

                // Stop the agent from moving
                agent.ResetPath();
            }
        }
    }
}
