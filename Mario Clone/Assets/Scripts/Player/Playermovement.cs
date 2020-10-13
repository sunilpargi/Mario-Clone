using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 15f;

    private Animator anim;
    private Rigidbody2D mybody;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private bool isgrounded;
    private bool jumped;
   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }
  

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
        PlayerWalk();
    }
    private void FixedUpdate()
    {
        
    }

    private void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0)
        {
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
            ChangeDirection(1);
        }
       else if (h < 0)
        {
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
            ChangeDirection(-1);
        }

        else
        {
            mybody.velocity = new Vector2(0f, mybody.velocity.y);
        }
        anim.SetInteger("Speed", Math.Abs((int)mybody.velocity.x));
    }

    void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
    void CheckIfGrounded()
    {
        isgrounded = Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.1f, groundLayer);
        
        if (isgrounded)
        {
            //and if we jumped before
            if (jumped)
            {
                jumped = false;
                anim.SetBool("Jump", false);
            }
        }
    }
    void PlayerJump()
    {
        if (isgrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumped = true;
                mybody.velocity = new Vector2(mybody.velocity.x, jumpForce);
                anim.SetBool("Jump", true);
            }
        }
    }
}//class





















































































































