using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{

    public float upForce = 100;
    public float speed = 20;
    public float runSpeed = 100;
    public bool isGrounded = false;
    public bool IsLeftDown = false;
    Animator anim;
    Rigidbody rb;
    SpriteRenderer sr;
    float moveHorizontal;

 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

   
    void Update()
    {

        IsLeftDown = Input.GetKey(KeyCode.LeftShift); 
        moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * upForce);
            isGrounded = false;
        }

        if (moveHorizontal > 0)
        {
            sr.flipX = false;
        }
        else if(moveHorizontal < 0)
        {
            sr.flipX = false;
        }
        
        if(moveHorizontal == 0)
    {
        anim.SetBool("Is Running", false);
    }
    else
    {
        anim.SetBool("Is Running", true);
    }

        }
    
    void FixedUpdate()
    {
        if (IsLeftDown)
        {
            rb.velocity = new Vector3((moveHorizontal) * runSpeed * Time.deltaTime, rb.velocity.y,0);
        }
        else 
        {
            rb.velocity = new Vector3((moveHorizontal) * speed * Time.deltaTime, rb.velocity.y,0);
        }

    }
    

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}