using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
    
{
    public NavMeshAgent agent;
    public Transform point1;
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
        if(point1 == null) 
        { 
            return; 
        }

        agent.SetDestination(point1.position);


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
