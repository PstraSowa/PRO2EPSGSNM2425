using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AIController : MonoBehaviour

{
    public NavMeshAgent agent;
    //public Transform point1;
    //public Transform point2;
    public float stoppingDistanceCheck = 0.01f;

    private bool isGoingToPoint1 = true;
    public int targetIndex = 0;

    public List<Transform> points;

    Animator anim;
    SpriteRenderer sr;
    float moveHorizontal;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count < 1)
        {

            return;
        }
        if (agent.remainingDistance < stoppingDistanceCheck)
        {
            targetIndex = Random.Range(0,points.Count);
            /*targetIndex++;
            if (targetIndex >= points.Count)
            {
                targetIndex = 0;
            }*/
        }
        agent.SetDestination(points[targetIndex].position);

        /* if(point1 == null || point2 == null) 
         { 
             return; 
         }

         if(agent.remainingDistance < stoppingDistanceCheck)
         {
             isGoingToPoint1 = !isGoingToPoint1;
         }
         if(isGoingToPoint1)
         {
             agent.SetDestination(point1.position);
         }
         else
         {
             agent.SetDestination(point2.position);
         }*/


        if (agent.velocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (agent.velocity.x < 0)
        {
            sr.flipX = true;
        }

        if (agent.velocity.magnitude == 0 && agent.velocity.magnitude == 0)
        {
            anim.SetBool("Is Running", false);
        }
        else
        {
            anim.SetBool("Is Running", true);
        }
    }
}
