using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private float speed = 5f;

    private Animator anim;
    private Rigidbody2D mybody;

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
        }
       else if (h < 0)
        {
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
        }

    }
}//class





























































































