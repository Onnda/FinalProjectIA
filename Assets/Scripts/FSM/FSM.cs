using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour
{
    public Transform cop; 
    public GameObject treasure; 
    public float dist2Steal = 10f; 
    Moves moves; 
    UnityEngine.AI.NavMeshAgent agent;

    private WaitForSeconds wait = new WaitForSeconds(0.05f); 

    delegate IEnumerator State();
    private State state; 

    // Coroutine that runs at the start of the script
    IEnumerator Start()
    {
        moves = gameObject.GetComponent<Moves>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        yield return wait; 

        state = Wander; 

        // Main loop to keep calling the current state as long as the script is enabled
        while (enabled)
            yield return StartCoroutine(state()); 
    }

   
    IEnumerator Wander()
    {
        Debug.Log("Wander state");

        // Loop to keep wandering until the cop is close to the treasure
        while (Vector3.Distance(cop.position, treasure.transform.position) < dist2Steal)
        {
            moves.Wander(); 
            yield return wait; 
        };

        // Transition to the Approaching state once the cop is close to the treasure
        state = Approaching;
    }

    
    IEnumerator Approaching()
    {
        Debug.Log("Approaching state"); 

        agent.speed = 2f; 
        moves.Seek(treasure.transform.position); // Move toward the treasure

        bool stolen = false; // Track if the treasure has been stolen

        // Loop until the character either reaches the treasure or the cop gets too close
        while (Vector3.Distance(cop.position, treasure.transform.position) > dist2Steal)
        {
            // Check if the character is close enough to the treasure to steal it
            if (Vector3.Distance(treasure.transform.position, transform.position) < 2f)
            {
                stolen = true; 
                break; 
            };
            yield return wait; 
        };

        // State transitions based on whether the treasure was stolen
        if (stolen)
        {
           
            treasure.GetComponent<Renderer>().enabled = false;
            Debug.Log("Stolen");
            state = Hiding; 
        }
        else
        {
            
            agent.speed = 1f;
            state = Wander; 
        }
    }

    
    IEnumerator Hiding()
    {
        Debug.Log("Hiding state"); 

        // Infinite loop to keep the character hiding indefinitely
        while (true)
        {
            moves.Hide();
            yield return wait; 
        };
    }
}