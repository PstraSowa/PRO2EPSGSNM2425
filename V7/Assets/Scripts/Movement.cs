using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CollectibleCounter))]

public class Movement : MonoBehaviour
{

    public float upForce = 1000;
    public float speed = 5;
    public float runSpeed = 7;
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
        //IsUpArrowDown = Input.GetKey(KeyCode.UpArrow);
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

        if (moveHorizontal == 0 && moveVertical == 0)
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
            rb.velocity = new Vector3((moveHorizontal) * runSpeed * Time.deltaTime, rb.velocity.y, (moveVertical) * runSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector3((moveHorizontal) * speed * Time.deltaTime, rb.velocity.y, (moveVertical) * speed * Time.deltaTime);
        }

        //if (IsUpArrowDown)
        //        {
        //            rb.velocity = new Vector4(0, rb.velocity.y, );
        //        }
        //        else
        //        {
        //            rb.velocity = new Vector4(0, rb.velocity.y, );

        //        }
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

    public void Save()
    {
        SaveData.instance.playerX = transform.position.x;
        SaveData.instance.playerY = transform.position.y;
        SaveData.instance.playerZ = transform.position.z;

    }

    public void Load()
    {
        transform.position = new Vector3(
            SaveData.instance.playerX, 
            SaveData.instance.playerY, 
            SaveData.instance.playerZ);
    }
}
