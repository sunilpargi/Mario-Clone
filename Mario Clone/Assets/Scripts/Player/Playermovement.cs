using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private float speed = 5f;

    private Animator anim;
    private Rigidbody2D mybody;

    public Transform groundCheckPosition;
    public LayerMask groundLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(groundCheckPosition.position, Vector2.down, 0.5f, groundLayer))
        {
            print("grounded");
        }
    }
    private void FixedUpdate()
    {
        PlayerWalk();
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
}//class





























































































