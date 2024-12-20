using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{

    public float upForce = 1000;
    public float speed = 20;
    public float runSpeed = 100;
    public bool isGrounded = false;
    public bool IsLeftDown = false;
    public bool IsUpArrowDown = false;
    Animator anim;
    Rigidbody rb;
    SpriteRenderer sr;
    float moveHorizontal;
    float moveVertical;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {

        IsLeftDown = Input.GetKey(KeyCode.LeftShift);
        IsUpArrowDown = Input.GetKey(KeyCode.UpArrow);
        //IsDownArrowDown = Input.GetKey(KeyCode.DownArrow);
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * upForce);
            isGrounded = false;
            
        }

        if (isGrounded == false) { anim.SetBool("IsJumping", true); }
        else
        {
            anim.SetBool("IsJumping", false);
        }
            
            
            if (moveHorizontal > 0)
        {
            sr.flipX = false;
        }
        else if (moveHorizontal < 0)
        {
            sr.flipX = true;
        }

        if (moveHorizontal == 0)
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
            rb.velocity = new Vector3((moveHorizontal) * runSpeed * Time.deltaTime, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3((moveHorizontal) * speed * Time.deltaTime, rb.velocity.y, 0);
        }

        if (IsUpArrowDown)
                {
                    rb.velocity = new Vector4(0, rb.velocity.y, (moveVertical) * speed * Time.deltaTime);
                }
                else
                {
                    rb.velocity = new Vector4(0, rb.velocity.y, (moveVertical) * speed * Time.deltaTime);

                }
        /*
                if (IsDownArrowDown)
                {
                    rb.velocity = new Vector4(0, rb.velocity.y, (moveHorizontal) * speed * Time.deltaTime);
                }
                else
                {
                    rb.velocity = new Vector4(0, rb.velocity.y, (moveHorizontal) * speed * Time.deltaTime);
                }*/
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}