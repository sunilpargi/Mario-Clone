using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject fireBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShotBullet();
    }

    private void ShotBullet()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject bullet = Instantiate(fireBullet, transform.position, quaternion.identity);

            bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
        }
    }

  
}
