using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject stone;
    public Transform attackInstantiate;

    private Animator anim;

    private string coroutine_Name = "StartAttack";
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(coroutine_Name);
    }
    // Update is called once per frame
 public void Attack()
    {
      GameObject obj = Instantiate(stone, attackInstantiate.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -700f), 0));
    }
   public void BackToIdle()
    {
        anim.Play("BossIdle");
    }

    public void DeactivateScript()
    {
        StopCoroutine(coroutine_Name);
        enabled = false;
    }
    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        anim.Play("BossAttack");
        StartCoroutine(StartAttack());
    }
}
