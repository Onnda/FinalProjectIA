using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerscript : MonoBehaviour
{
    public Transform leader; 
    public float speed = 2f; 
    public float minmumdistance = 2f; 


   
    void Update()
    {
        if (leader != null)
        {
            
            float distance = Vector3.Distance(transform.position, leader.position);

            
            if (distance > minmumdistance)
            {
                Vector3 direccion = (leader.position - transform.position).normalized;
                transform.position += direccion * speed * Time.deltaTime;
            }
        }



    }
}
