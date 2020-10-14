using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public Transform bottom_Collision;

    private Animator anim;

    public LayerMask playerLayer;

    private Vector3 moveDirection = Vector3.up;
    private Vector3 originPosition;
    private Vector3 animPosition;
    private bool startAnim;
    private bool canAnimate = true;

    void Awake()
    {
        
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        originPosition = transform.position;
        animPosition = transform.position;
        animPosition.y += 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCOllison();
        AnimationUpDown();
      
    }



    private void CheckForCOllison()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(bottom_Collision.position, Vector2.down, 0.1f, playerLayer);
           
            if (hit)
            {
                if (hit.collider.gameObject.tag == MyTag.PLAYER_TAG)
                {
                    print("Collider");
                    anim.Play("BlockHit");
                    startAnim = true;

                    canAnimate = false;
                }
            }

           
        }
    
    }

    private void AnimationUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime);

            if (transform.position.y >= animPosition.y)
            {
                moveDirection = Vector2.down;
            }
            else if (transform.position.y <= originPosition.y)
            {
                startAnim = false;
            }
        }
    }
}
