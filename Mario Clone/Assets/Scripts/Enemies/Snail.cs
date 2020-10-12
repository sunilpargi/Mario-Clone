using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D mybody;
    private Animator anim;

    public LayerMask playerlayer;

    private bool move_Left;
    private bool can_Move;
    private bool stunned;

    public Transform left_Collison, right_Collison,down_Collison, top_Collison;
    private Vector3 left_Collison_Pos, right_Collison_Pos;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();

        left_Collison_Pos = left_Collison.position;
        right_Collison_Pos = right_Collison.position;
    }

    void Start()
    {
        move_Left = true;
        can_Move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_Move)
        {
            if (move_Left)
            {
                mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
            }
        }

        CheckCollison();
    }

    void CheckCollison()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collison_Pos, Vector2.left, 0.1f, playerlayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_Collison_Pos, Vector2.right, 0.1f, playerlayer);

        Collider2D topHit = Physics2D.OverlapCircle(top_Collison.position, 0.2f, playerlayer);

        if (topHit)
        {
            if(topHit.gameObject.tag == MyTag.PLAYER_TAG)
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    can_Move = false;
                    mybody.velocity = Vector2.zero;

                    anim.Play("Stunned");
                    stunned = true;

                    if(tag == MyTag.BETTLE_TAG)
                    {
                        anim.Play("Stunned");
                        StartCoroutine(Dead(0.5f));
                    }
                }
            }
        }

        if (leftHit)
        {
            if(leftHit.collider.gameObject.tag == MyTag.PLAYER_TAG)
            {
                if (!stunned)
                {
                    print("Damage");
                }
                else
                {
                    if (tag != MyTag.BETTLE_TAG)
                    {
                        mybody.velocity = new Vector2(15f, mybody.velocity.y);
                        print("Push right");
                        StartCoroutine(Dead(3f));
                    }
                     
                }
            }
        }
        if (rightHit)
        {
            if (rightHit.collider.gameObject.tag == MyTag.PLAYER_TAG)
            {
                if (!stunned)
                {
                    print("Damage");
                }
                else
                {
                    if(tag != MyTag.BETTLE_TAG)
                    {
                        mybody.velocity = new Vector2(-15f, mybody.velocity.y);
                        print("Push left");
                        StartCoroutine(Dead(3f));
                    }
                   
                }
            }
        }

        if (!Physics2D.Raycast(down_Collison.position, Vector2.down, 0.1f))
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

            left_Collison_Pos = left_Collison.position;
            right_Collison_Pos = right_Collison.position;
        }
        else
        {
            tempScale.x = - Mathf.Abs(tempScale.x);

            left_Collison_Pos = right_Collison.position;
            right_Collison_Pos = left_Collison.position;
        }
        transform.localScale = tempScale;
    }

    IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);

        gameObject.SetActive(false);
    }
}



































































