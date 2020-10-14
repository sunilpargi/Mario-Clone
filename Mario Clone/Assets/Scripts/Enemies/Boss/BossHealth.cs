using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private Animator anim;
    private int health = 1;

    private bool canDamage;
    void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (canDamage)
        {
            if (target.tag == MyTag.BULLET_TAG)
            {
                health--;
                canDamage = false;

                if (health <= 0)
                {
                    GetComponent<Boss>().DeactivateScript();
                    anim.Play("BossDead");
                        
                }
                StartCoroutine(WaitForDamage());
            }
        }
    }
 
    

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(3f);

        canDamage = true;
    }
}
