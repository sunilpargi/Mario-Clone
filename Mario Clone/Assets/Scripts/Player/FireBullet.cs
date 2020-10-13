using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;
    private Animator anim;
    private bool CanMove;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        CanMove = true;
        StartCoroutine(DisableBullet(5f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (CanMove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
      
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == MyTag.BETTLE_TAG || target.gameObject.tag == MyTag.SNAIL_TAG || target.gameObject.tag == MyTag.SPIDER_TAG)
        {
            anim.Play("Explode");
            CanMove = false;
            StartCoroutine(DisableBullet(0.1f));

        }
    }
}
