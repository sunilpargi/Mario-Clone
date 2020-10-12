using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D mybody;
    private Animator anim;

    private bool move_Left;

    public Transform down_collison;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        move_Left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move_Left)
        {
            mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);
        }
        else
        {
            mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
        }

        CheckCollison();
    }

    void CheckCollison()
    {
        if(!Physics2D.Raycast(down_collison.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        move_Left = !move_Left;

        Vector3 tempScale = transform.localScale;

        if (move_Left)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = - Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
    }
}



































































