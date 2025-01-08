using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Patrol : MonoBehaviour
{
    int i = 0;
    NavMeshAgent agent;
    Vector3 patata;
    float randomX;
    float randomZ;
    public Transform[] waypoint;
    Quaternion macarron;
    float randomA;
    float randomB;
    float randomC;
    float randomD;
    float pi = Mathf.PI;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Random position spawn

        //randomX = Random.Range(-30f, 30f);
        //randomZ = Random.Range(-30f, 30f);

        //Random angle

        //randomA = Random.Range(0.0f, 2*pi);
        //randomB = Random.Range(0.0f, 2*pi);
        //randomC = Random.Range(0.0f, 2*pi);
        //randomD = Random.Range(0.0f, 2*pi);

        //macarron.x = randomA;
        //macarron.y = randomB;
        //macarron.z = randomC;
        //macarron.w = randomD;

        //patata = new Vector3(randomX, 0f, randomZ);
        //agent.transform.SetPositionAndRotation(patata, macarron);

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(waypoint[i].position);

        if (Vector3.Distance(waypoint[i].position,transform.position) < 1.5f)
        {
            i++;
            if(waypoint.Length == i) {
                i = 0;
            }

        }
    }
}
