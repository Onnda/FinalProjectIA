using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of the character
    public float moveInterval = 2f; // Time interval between movements
    public float range = 5f; // Range for random movement

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        // Set the initial target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the character has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Set a new random target position
            SetRandomTargetPosition();
        }
    }

    private void SetRandomTargetPosition()
    {
        // Generate a random position within the specified range
        targetPosition = new Vector3(
            Random.Range(-range, range),
            transform.position.y, // Keep the same height
            Random.Range(-range, range)
        );

        // Reset the timer
        timer = 0f;
    }
}
