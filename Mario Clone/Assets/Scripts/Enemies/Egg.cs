﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == MyTag.PLAYER_TAG)
        {
            target.gameObject.GetComponent<PlayerDamage>().DealDamage();
        }
        gameObject.SetActive(false);

    }
}
