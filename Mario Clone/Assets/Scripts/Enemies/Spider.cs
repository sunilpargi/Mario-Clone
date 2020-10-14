using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private float speed = 2.5f;
    private Rigidbody2D mybody;
    private Animator anim;
    private string couroutine_Name = "ChangeDirection";

    private Vector3 moveDirection = Vector3.down;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(couroutine_Name);
    }

    // Update is called once per frame
    void Update()
    {
        MoveSpider();
    }

    private void MoveSpider()
    {
        transform.Translate(moveDirection * Time.smoothDeltaTime);
 
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds (UnityEngine.Random.Range(2f,5f));

        if (moveDirection == Vector3.down)
        {
            moveDirection = Vector3.up;
        }
        else
        {
            moveDirection = Vector3.down;
        }

        StartCoroutine(couroutine_Name);
      
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == MyTag.BULLET_TAG)
        {
            anim.Play("SpiderDead ");

            mybody.bodyType = RigidbodyType2D.Dynamic;

            StartCoroutine(SpiderDied());
            StopCoroutine(couroutine_Name);
        }

        if(target.tag == MyTag.PLAYER_TAG)
        {
            target.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
    }

    IEnumerator SpiderDied()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }
}
