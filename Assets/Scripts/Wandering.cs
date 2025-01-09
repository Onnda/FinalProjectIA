using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    float randomX;
    float randomZ;

    public int limits = 30;

    public Vector3 pallah;  

    NavMeshAgent agente;

   

   
    void Start()
    {
       
        agente = GetComponent<NavMeshAgent>();

        
        if (agente == null)
        {
            Debug.LogError("No se encontró un componente NavMeshAgent en el GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (agente.velocity.magnitude < 1.0f )
        {
            
            randomX = Random.Range(-limits, limits);
            randomZ = Random.Range(-limits, limits);

            
            pallah = new Vector3(randomX, transform.position.y, randomZ);

            
            agente.SetDestination(pallah);
        }
    }
}
